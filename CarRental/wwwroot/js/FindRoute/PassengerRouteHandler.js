import { RouteHandler } from './RouteHandler.js'
import { getRoute } from './findRoute.js';

export class PassengerRouteHandler extends RouteHandler {
    async handleRoute(startCoords, targetCoords, formData) {
        const routeFound = await getRoute(startCoords, targetCoords);
        if (routeFound) {
            alert("Passenger needs to confirm additional steps.");
            // Implement additional steps for passengers
            const confirmed = confirm("Do you want to save this route?");
            if (confirmed) {
                //await saveToDatabase(formData);
            }
        } else {
            alert("Route not found or invalid.");
        }
    }
}