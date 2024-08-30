
export class CustomEvent {

    /**
     * 
     * @param {string} eventName 
     * @param {string} querySelectorName
     * @param {Function} eventHandler
     */
    constructor(eventName,querySelectorName,eventHandler) {
        this.EventName = eventName;
        this.EventHandler = eventHandler;
        this.QuerySelectorName = querySelectorName;
    }

    /**
     * 
     * @returns {ParentNode}
     */
    getDocumentQuery = () => {
        return document.querySelector(this.QuerySelectorName);
    }
    
}

