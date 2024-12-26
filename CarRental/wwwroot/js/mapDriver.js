// Initialize the map
let map = L.map('map').setView([0, 0], 2); // Default global view

// Add OpenStreetMap tile layer
L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

// Global variable for the route layer
let routeLayer = null;

// Function to find the route and display it on the map
async function findSharedRoute() {
    // Get user input values
    const startLocation = document.getElementById('start-location').value;
    const endLocation = document.getElementById('end-location').value;

    if (!startLocation || !endLocation) {
        alert('Please enter both start and end locations.');
        return;
    }

    // Fetch coordinates for the start and target locations
    const [startCoords, targetCoords] = await Promise.all([
        geocodeLocation(startLocation),
        geocodeLocation(endLocation) // Fixed variable name
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

// Helper function to add a marker to the map
function addMarker(lat, lon, type) {
    const marker = L.marker([lat, lon]).addTo(map);
    marker.bindPopup(`${type === 'start' ? 'Start' : 'End'} Location: [${lat}, ${lon}]`).openPopup();
}

// Helper function to fetch and display the route
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
}

// Helper function to geocode a location using OpenStreetMap's Nominatim API
async function geocodeLocation(location) {
    try {
        const response = await fetch(`https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(location)}`);
        const data = await response.json();

        if (data.length === 0) return null;

        const { lat, lon } = data[0];
        return [parseFloat(lat), parseFloat(lon)];
    } catch (error) {
        console.error("Error geocoding location:", error);
        return null;
    }
}
