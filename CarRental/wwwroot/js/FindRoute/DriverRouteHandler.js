import { RouteHandler } from './RouteHandler.js'
import { getRoute } from './findRoute.js';

export class DriverRouteHandler extends RouteHandler {
    async handleRoute(startCoords, targetCoords, formData) {
        alert("Looking path for driver!");
        const routeFound = await getRoute(startCoords, targetCoords);
        if (routeFound) {
            await saveToDatabase(formData);
        } else {
            alert("Route not found or invalid.");
        }
    }
}
const fakeData = {
    StartLocation: "Start Location",
    EndLocation: "End Location",
    Seats: 3,
    DepartTime: "14:00:12", // This should match TimeOnly format
    DepartDate: "2024-12-27", // This should match DateTime format
};
async function saveToDatabase(data) {
    try {
        console.log(data);
        const response = await fetch('/ShareDrive/SaveDriverRoute', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            
            body: JSON.stringify(data),
        });
        const result = await response.json();
        if (response.ok) {
            alert(result.message);
        } else {
            console.error('Error saving route:', response.statusText);
            alert('Failed to save route. Please try again.');
        }
    } catch (error) {
        console.error('Error during fetch:', error);
        alert('An error occurred. Please try again.');
    }
}

