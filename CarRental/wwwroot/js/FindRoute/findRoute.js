import { DriverRouteHandler } from './DriverRouteHandler.js'
import { PassengerRouteHandler } from './PassengerRouteHandler.js'
import { RouteContext } from './RouteContext.js'

let passengerRouteLayer, driverRouteLayer;
const apiKey = '5b3ce3597851110001cf6248e2f1acef377948cbb257b744da9b7764';
// Initialize the map
export let map = L.map('map').setView([0, 0], 2); // Default global view

// Add OpenStreetMap tile layer
L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

// Function to find the route and display it on the map
async function findRoute(userType) {
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
    if (!startCoords) {
        alert('Could not find ' + startLocation);
        return;
    }
    if (!targetCoords) {
        alert('Could not find ' + endLocation);
        return;
    }
    // Add markers for the locations
    addMarker(startCoords[0], startCoords[1], 'start');
    addMarker(targetCoords[0], targetCoords[1], 'target');

    let handler = null;
    if (userType === 'driver') {
        handler = new DriverRouteHandler();
    } else if (userType === 'passenger') {
        handler = new PassengerRouteHandler();
    } else {
        throw new Error("Unknown user type");
    }

    var departTime = document.querySelector('[name="DepartTime"]');
    var departDate = document.querySelector('[name="DepartDate"]');
    const formData = {
        StartLocation: startLocation,
        EndLocation: endLocation,
        Seats: document.querySelector('[name="Seats"]').value,
        DepartTime: departTime.value ? departTime.value + ":00" : null,
        DepartDate: departDate.value ? departDate.value : null
    };
    console.log(formData);

    const routeContext = new RouteContext(handler);
    await routeContext.executeRoute(startCoords, targetCoords, formData);
    
}

// Helper function to add a marker to the map
function addMarker(lat, lon, type) {
    const marker = L.marker([lat, lon]).addTo(map);
    marker.bindPopup(`${type === 'start' ? 'Start' : 'End'} Location: [${lat}, ${lon}]`).openPopup();
}
// Helper function to fetch and display the route



let routeLayer = null;
export async function getRoute(startCoords, targetCoords) {
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

        return true; // a route is found and display
    } catch (error) {
        console.error('Error fetching route:', error);
        alert('Could not fetch route. Please try again.');
        return false;
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


/* ============== Share Drive ======================== */
async function getRoute2(start, end) {
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
    if (!Array.isArray(route1) || !Array.isArray(route2)) {
        console.error("Expected arrays for routes, but got:", typeof route1, typeof route2);
        return false; // Return false if routes are not arrays
    }
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
    return similarityPercentage > 30; // Consider routes similar if 30% overlap
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


export async function findSharedRoute(passengerStart, passengerEnd, driverStart, driverEnd) {

    if (!passengerStart || !passengerEnd || !driverStart || !driverEnd) {
        console.error('start or end == null');
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
        getRoute2(passengerCoords[0], passengerCoords[1]),
        getRoute2(driverCoords[0], driverCoords[1])
    ]);
    if (!passengerRoute || !driverRoute) {
        console.error('Could not fetch routes for one or both locations.');
        return false; // Return false if any route is not available
    }
    if (passengerRoute && driverRoute) {
        // Draw routes on the map
        /*if (passengerRouteLayer) map.removeLayer(passengerRouteLayer);
        if (driverRouteLayer) map.removeLayer(driverRouteLayer);*/

        /*passengerRouteLayer = drawRoute(passengerRoute, 'blue');
        driverRouteLayer = drawRoute(driverRoute, 'green');*/

        //map.fitBounds(passengerRouteLayer.getBounds());

        // Compare routes
        const similar = areRoutesSimilar(passengerRoute, driverRoute, 0.5);
        if (similar) {
            console.log('The routes are similar! A shared ride is possible.');
            return true;
        } else {
            console.log('The routes do not overlap significantly.');
            return false;
        }
    } else {
        alert('Could not fetch one or both routes.');
        return false;
    }
}

/*async function geocodeLocation(location) {
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
}*/


function drawRoute(route, color) {
    return L.polyline(route, { color: color, weight: 5 }).addTo(map);
}


window.findRoute = findRoute;

