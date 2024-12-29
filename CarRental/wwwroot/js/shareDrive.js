const apiKey = '5b3ce3597851110001cf6248e2f1acef377948cbb257b744da9b7764';
let passengerRouteLayer, driverRouteLayer;

// Initialize the map
const map = L.map('map').setView([51.505, -0.09], 13);

// Add OpenStreetMap tiles
L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '© OpenStreetMap contributors'
}).addTo(map);

async function getRoute(start, end) {
    const url = `https://api.openrouteservice.org/v2/directions/driving-car?api_key=${apiKey}&start=${start[1]},${start[0]}&end=${end[1]},${end[0]}`;
    try {
        const response = await fetch(url);
        const data = await response.json();
        return data.features[0].geometry.coordinates.map(coord => [coord[1], coord[0]]);
    } catch (error) {
        console.error('Error fetching route:', error);
        alert('Could not fetch route. Please try again.');
        return null;
    }
}

function areRoutesSimilar(route1, route2, threshold = 0.5) {
    let sharedSegments = 0;
    let totalSharedDistance = 0; // Accumulate shared distance

    route1.forEach((point1, index1) => {
        route2.forEach((point2, index2) => {
            const distance = haversineDistance(point1, point2);
            if (distance <= threshold) {
                sharedSegments++;
                // Add segment distance for overlapping routes
                if (index1 > 0 && index2 > 0) {
                    totalSharedDistance += haversineDistance(route1[index1 - 1], route2[index2 - 1]);
                }
            }
        });
    });

    // Define the similarity as a percentage of shared points
    const similarityPercentage = (sharedSegments / route1.length) * 100;
    return {
        isSimilar: similarityPercentage > 30, // Consider routes similar if 30% overlap
        sharedDistance: totalSharedDistance,
    }
}

// Haversine distance to calculate proximity in kilometers
function haversineDistance(coord1, coord2) {
    const R = 6371; // Earth's radius in km
    const dLat = ((coord2[0] - coord1[0]) * Math.PI) / 180;
    const dLon = ((coord2[1] - coord1[1]) * Math.PI) / 180;
    const lat1 = (coord1[0] * Math.PI) / 180;
    const lat2 = (coord2[0] * Math.PI) / 180;

    const a =
        Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(lat1) * Math.cos(lat2) * Math.sin(dLon / 2) * Math.sin(dLon / 2);
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    return R * c; // Distance in km
}

async function findSharedRoute(passengerStart, passengerEnd, driverStart, driverEnd) {

    if (!passengerStart || !passengerEnd || !driverStart || !driverEnd) {
        alert('Please fill in all fields.');
        return 0;
    }
    console.log(passengerStart)
    console.log(passengerEnd)
    console.log(driverStart)
    console.log(driverEnd)

    // Geocode start and end locations using OpenRouteService (similar to Nominatim example)
    const passengerCoords = await Promise.all([
        geocodeLocation(passengerStart),
        geocodeLocation(passengerEnd)
    ]);

    const driverCoords = await Promise.all([
        geocodeLocation(driverStart),
        geocodeLocation(driverEnd)
    ]);

    // Fetch routes
    const [passengerRoute, driverRoute] = await Promise.all([
        getRoute(passengerCoords[0], passengerCoords[1]),
        getRoute(driverCoords[0], driverCoords[1])
    ]);

    if (passengerRoute && driverRoute) {
        // Draw routes on the map
        if (passengerRouteLayer) map.removeLayer(passengerRouteLayer);
        if (driverRouteLayer) map.removeLayer(driverRouteLayer);

        passengerRouteLayer = drawRoute(passengerRoute, 'blue');
        driverRouteLayer = drawRoute(driverRoute, 'green');

        map.fitBounds(passengerRouteLayer.getBounds());

        // Compare routes
        const { isSimilar, sharedDistance } = areRoutesSimilar(passengerRoute, driverRoute, 0.5);
        if (isSimilar) {
            alert('The routes are similar! A shared ride is possible.');
            return sharedDistance;
        } else {
            alert('The routes do not overlap significantly.');
            return -1;
        }
    } else {
        alert('Could not fetch one or both routes.');
        return -1;
    }
}

async function geocodeLocation(location) {
    const url = `https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(location)}`;
    try {
        const response = await fetch(url);
        const results = await response.json();
        if (results.length > 0) {
            return [parseFloat(results[0].lat), parseFloat(results[0].lon)];
        } else {
            throw new Error('Location not found');
        }
    } catch (error) {
        console.error('Error geocoding location:', error);
        return null;
    }
}


function drawRoute(route, color) {
    return L.polyline(route, { color: color, weight: 5 }).addTo(map);
}