import { CustomEvent } from '../common/CustomEvent.js';


export const EventArray = [
    /**
     * Menu toggle event
     */
    new CustomEvent(
        "click",
        ".js-top-menu-button",
        /**
         * 
         * @param {MouseEvent} e
         */
        function (e) {

            /**
             * @type {ParentNode}
             */
            const menu = document.querySelector(".cms-editpage-top__menu__group");

            if ([...document.querySelector(".cms-editpage-top__menu__group").classList].indexOf("cms-editpage-top__menu__group--toggle") == -1) {
                menu.classList.add("cms-editpage-top__menu__group--toggle");

            } else {
                menu.classList.remove("cms-editpage-top__menu__group--toggle");
            }

        },
    ),
]