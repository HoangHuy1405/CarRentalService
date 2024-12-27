import { RouteHandler } from './RouteHandler.js'

export class RouteContext {
    constructor(RouteHandler) {
        this.RouteHandler = RouteHandler;
    }
    async executeRoute(startCoords, targetCoords, formData) {
        await this.RouteHandler.handleRoute(startCoords, targetCoords, formData);
    }
}
