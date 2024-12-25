
const apiKey = '5b3ce3597851110001cf6248e2f1acef377948cbb257b744da9b7764';
let passengerRouteLayer, driverRouteLayer;

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

    route1.forEach(point1 => {
        route2.forEach(point2 => {
            const distance = haversineDistance(point1, point2);
            if (distance <= threshold) {
                sharedSegments++;
            }
        });
    });

    // Define the similarity as a percentage of shared points
    const similarityPercentage = (sharedSegments / route1.length) * 100;
    return similarityPercentage > 80; // Consider routes similar if 30% overlap
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

// Compare routes for similarity
function areRoutesSimilar(route1, route2, threshold = 0.5) {
    let sharedSegments = 0;

    route1.forEach(point1 => {
        route2.forEach(point2 => {
            const distance = haversineDistance(point1, point2);
            if (distance <= threshold) {
                sharedSegments++;
            }
        });
    });

    // Define similarity as a percentage of shared points
    const similarityPercentage = (sharedSegments / route1.length) * 100;
    return similarityPercentage > 30; // Shared ride possible if >30% of the route overlaps
}


async function findSharedRoute() {
    const passengerStart = document.getElementById('passenger-start').value;
    const passengerEnd = document.getElementById('passenger-end').value;
    const driverStart = document.getElementById('driver-start').value;
    const driverEnd = document.getElementById('driver-end').value;

    if (!passengerStart || !passengerEnd || !driverStart || !driverEnd) {
        alert('Please fill in all fields.');
        return;
    }

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
        const similar = areRoutesSimilar(passengerRoute, driverRoute, 0.5);
        if (similar) {
            alert('The routes are similar! A shared ride is possible.');
        } else {
            alert('The routes do not overlap significantly.');
        }
    } else {
        alert('Could not fetch one or both routes.');
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

// Example: Call the function with user inputs
/*findSharedRoute(
    [51.505, -0.09],  // Passenger start
    [51.515, -0.1],   // Passenger end
    [51.506, -0.08],  // Driver start
    [51.516, -0.11]   // Driver end
);*/



// Example: Draw both routes
/*drawRoute(passengerRoute, 'blue'); // Passenger route
drawRoute(driverRoute, 'green'); */