// Initialize the map
const map = L.map('map').setView([51.505, -0.09], 13);

// Add OpenStreetMap tiles
L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '© OpenStreetMap contributors'
}).addTo(map);



/*let startMarker, targetMarker, routeLayer;

// Add markers for start and target locations
function addMarker(lat, lng, type) {
    if (type === 'start') {
        if (startMarker) {
            startMarker.setLatLng([lat, lng]);
        } else {
            startMarker = L.marker([lat, lng], { draggable: true }).addTo(map);
        }
    } else if (type === 'target') {
        if (targetMarker) {
            targetMarker.setLatLng([lat, lng]);
        } else {
            targetMarker = L.marker([lat, lng], { draggable: true }).addTo(map);
        }
    }
    map.setView([lat, lng], 13);
}*/

// Function to find the shortest path
async function findShortestPath() {
    const startLocation = document.getElementById('start-location').value;
    const targetLocation = document.getElementById('target-location').value;

    // Fetch coordinates for the start and target locations
    const [startCoords, targetCoords] = await Promise.all([
        geocodeLocation(startLocation),
        geocodeLocation(targetLocation)
    ]);

    if (!startCoords || !targetCoords) {
        alert('Could not find one or both locations. Please try again.');
        return;
    }

    // Add markers for the locations
    addMarker(startCoords[0], startCoords[1], 'start');
    addMarker(targetCoords[0], targetCoords[1], 'target');

    // Fetch and display the route
    await getRoute(startCoords, targetCoords);
}

/*// Geocode location using Nominatim API
async function geocodeLocation(location) {
    const url = `https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(location)}`;
    try {
        const response = await fetch(url);
        const results = await response.json();
        if (results.length > 0) {
            return [parseFloat(results[0].lat), parseFloat(results[0].lon)];
        } else {
            return null;
        }
    } catch (error) {
        console.error('Error geocoding location:', error);
        return null;
    }
}*/

/*// Get the route using OpenRouteService API
async function getRoute(startCoords, targetCoords) {
    const apiKey = '5b3ce3597851110001cf6248e2f1acef377948cbb257b744da9b7764'; // Replace with your API key
    const url = `https://api.openrouteservice.org/v2/directions/driving-car?api_key=${apiKey}&start=${startCoords[1]},${startCoords[0]}&end=${targetCoords[1]},${targetCoords[0]}`;

    try {
        const response = await fetch(url);
        const data = await response.json();

        // Clear previous route layer
        if (routeLayer) {
            map.removeLayer(routeLayer);
        }

        // Draw the route on the map
        const coordinates = data.features[0].geometry.coordinates.map(coord => [coord[1], coord[0]]);
        routeLayer = L.polyline(coordinates, { color: 'blue', weight: 5 }).addTo(map);

        // Fit map to route bounds
        map.fitBounds(routeLayer.getBounds());
    } catch (error) {
        console.error('Error fetching route:', error);
        alert('Could not fetch route. Please try again.');
    }
}*/
