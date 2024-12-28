import { RouteHandler } from './RouteHandler.js'
import { getRoute } from './findRoute.js';
import { findSharedRoute } from './findRoute.js';

export class PassengerRouteHandler extends RouteHandler {
    async handleRoute(startCoords, targetCoords, formData) {
        const routeFound = await getRoute(startCoords, targetCoords);
        if (routeFound) {
            // query all driverRide with the same depart time and depart day goers (not compulsory)
            // => query all driverRide that have seatLeft > seat of goers
            // => use js to find all the driverRide with the sameRoute (10%)
            alert("Route found successfully!");
            getAllValidRoute(formData);

            

        } else {
            alert("Route not found or invalid.");
        }
    }
}

async function getAllValidRoute(formData) {
    try {
        console.log(formData);
        const response = await fetch('/ShareDrive/GetALLValidDriverRide', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData),
        });
        
        if (response.ok) {
            const drivers = await response.json();

            const driversArray = drivers.$values || [];
            // sort drivers even more and send to new page
            console.log(typeof drivers)
            console.log(typeof driversArray)
            const sortedDrivers = await filterSharedRoute(driversArray, formData);

            console.log("Valid driver routes:", driversArray);
            console.log("Valid shared driver routes:", sortedDrivers);
        } else {
            console.error('Error saving route:', response.statusText);
            alert('Failed to fetch driver routes');
        }
    } catch (error) {
        console.error('Error during fetch:', error);
        alert('An error occurred. Please try again.');
    }
}

async function filterSharedRoute(drivers, passenger) {
    // Loop through the sorted drivers and check for shared routes
    // Initialize an empty array to hold the valid (shared) drivers
    const validDrivers = [];
    for (let driver of drivers) {
        console.log(driver.startLocation);
        const isShared = await findSharedRoute(
            passenger.StartLocation,
            passenger.EndLocation,
            driver.startLocation,
            driver.endLocation
        );

        if (isShared) {
            console.log('Driver with ID ' + driver.DriverRideID + ' can share the route!');
            // Handle the result, like displaying the driver or adding to a list of valid drivers
            validDrivers.push(driver);
        }
    }
    console.log(validDrivers);
    return validDrivers;
}

