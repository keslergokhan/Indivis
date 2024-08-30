import { CustomEvent } from '../services/common/CustomEvent.js';
import { EventArray } from '../services/shared/CmsEditThemeService.js'

export class CmsEditPage {
   

    /**
     * 
     * @param {EventArray} eventArray
     */
    eventHandlers = (eventArray) => {
        eventArray.forEach(
            /**
             * 
             * @param {CustomEvent} event
             */
            (event) => {
                event.getDocumentQuery().addEventListener(event.EventName, event.EventHandler)
            })
    }
}


const cmsEditPage = new CmsEditPage();
cmsEditPage.eventHandlers(EventArray);


