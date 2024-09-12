
export const JustValidateMessage = {
    /**
    * Lütfen boş bırakmayınız !
    * @returns {string}
    */
    required: () => "Lütfen boş bırakmayınız !",
    /**
     * En az {a} karakter olabilir !
     * @param {Int32Array} a
     * @returns {string}
     */
    minLenght: (a) => `En az ${a} karakter olabilir !`,
    /**
     * En az {a} karakter olabilir !
     * @param {Int32Array} a
     * @returns {string}
     */
    maxLenght: (a) => `En çok ${a} karakter olabilir !`,
    /**
     * Lütfen uygun bir format giriniz !
     * @returns {string}
     */
    email:()=>"Lütfen uygun bir format giriniz !"

}


export class HelperFunction {

    /**
     * 
     * @param {string} text
     * @returns {string}
     */
    translateTextToSlug = (text) => {
        let invalidUrlCharacters = ['+', '&', '=', '?', '%', '#', '/', '\\', ';', ':', '@', '[', ']', '{', '}', '<', '>', '"', '\'', '^', '`', '|', '~', '!', '$', '(', ')', '*']; 

        let replaceArray = [
            ["ı", "i"],
            ["ö", "o"],
            ["ü", "u"],
            ["ç", "c"],
            ["ş", "s"],
            ["ğ","g"]
        ];

        invalidUrlCharacters.forEach((x) => {
            text = text.replace(x, '').replace(' ','-');
        });

        replaceArray.forEach(x => {
            text = text.replace(x[0], x[1]);
        })

        return `/${text}`;
    }
    /**
     * formdata elemanlarını key:value şeklinde object dönüştürür
     * @param {FormData} formData
     * @return {object}
     */
    formDataToJsonObject=(formData) => {
        var jsonObject = {};

       
        formData.forEach(function (value, key) {

            let keys = key.split('.'); // 'Page.Title' string'ini '.' ile ayırıp bir diziye atayalım
            let currentObj = jsonObject;

            // Objeyi iç içe olacak şekilde oluşturalım
            for (let i = 0; i < keys.length; i++) {
                if (i === keys.length - 1) {
                    currentObj[keys[i]] = value; // Son öğede değeri ekleyelim
                } else {
                    currentObj[keys[i]] = currentObj[keys[i]] || {}; // Objeyi oluşturalım
                    currentObj = currentObj[keys[i]]; // Sonraki öğeye geçelim
                }
            }
            
            
        });


        return jsonObject;
    }

    /**
     * 
     * @param {ParentNode} element toggle işlemi uygulanacak element
     * @param {string} toggleClass toggle aktif olacak class
     */
    toggleClass=(element,toggleClass) => {
        if ([...element.classList].indexOf(toggleClass) == -1) {
            element.classList.add(toggleClass);

        } else {
            element.classList.remove(toggleClass);
        }
    }
    /**
     * 
     * @param {Element} element
     */
    startSpinner = (element) => {
        element.classList.add("cms-spinner-border");
    }
    /**
     * 
     * @param {Element} element
     */
    stopSpinner = (element) => {
        element.classList.remove("cms-spinner-border");
    }
    /**
     * 
     * @param {Element} element
     */
    startWhiteSpinner = (element) => {
        element.classList.add("cms-spinner-white-border");
    }
    /**
     * 
     * @param {Element} element
     */
    stopWhiteSpinner = (element) => {
        element.classList.remove("cms-spinner-white-border");
    }

    modalEvent = (btn) => {

        const modalId = btn.getAttribute("data-cms-modal-id");

        const modal = document.querySelector(`#${modalId}`);

        if (!modal) {
            console.error(`Burada bir hata oluştu ${modalId} bulunamadı`);
        }

        const modalDialog = modal.querySelector(".cms-modal__dialog");

        const closeBtn = modal.querySelector(".cms-modal__dialog-close");

        btn.addEventListener('click', function (e) {
            modal.style.visibility = "visible";
            modalDialog.classList.add("cms-modal__dialog--show");
        });

        closeBtn.addEventListener('click', function (e) {
            e.target.closest(".cms-modal").style.visibility = "hidden";
            e.target.closest(".cms-modal__dialog").classList.remove("cms-modal__dialog--show");
        });
    }
}


class CmsModal {
    constructor(modalKey) {
        this.ModalKey = modalKey
        this.Modal = null;
        this.showButtonEvent();
        this.closeButtonEvent();
    }

    /**
     * 
     * @returns {Element}
     */
    getModal = () => {
        if (this.Element == null) {
            this.Modal = document.getElementById(this.ModalKey);
        }
        return this.Modal;
    }

    showButtonEvent = () => {
        const modalBtn = document.querySelector(`[data-cms-modal-key="${this.ModalKey}"]`);
        if (modalBtn) {
            document.querySelector(`[data-cms-modal-key="${this.ModalKey}"]`).addEventListener('click', () => {
                this.show();
            })
        }
        
    }

    closeButtonEvent = () => {
        const closeBtn = this.getModal().querySelector(".cms-modal__dialog-close");
        if (closeBtn) {
            closeBtn.addEventListener('click', () => {
                this.hide();
            });
        }
    }

    show = () => {
        this.getModal().style.visibility = "visible";
        this.getModal().querySelector(".cms-modal__dialog").classList.add("cms-modal__dialog--show");
    }

    hide = () => {
        this.getModal().style.visibility = "hidden";
        this.getModal().querySelector(".cms-modal__dialog").classList.remove("cms-modal__dialog--show");
    
    }
    
}

class WidgetFormIframe {
    constructor() {
        this.Element = document.querySelector(".js-widget-form-iframe");
        this.closeButtonEvent();
    }

   

    closeButtonEvent = () => {
        this.Element.querySelector(".js-widget-form-iframe-close").addEventListener('click', () => {
            this.hide();
        });
    }

    /**
     * WidgetForm yapısını getiren iframe src düzenle
     * @param {string} widgetId
     * @param {string} widgetTemplateId
     * @returns
     */
    setIframeSrc = (widgetId, widgetTemplateId) => {
        return this.Element.querySelector("iframe").src = `/api/widgetformapi/getform/${widgetId}/${widgetTemplateId}`;
    }

    /**
     * WidgetFormIframe tasarımını aktifet
     * @param {string} title
     * @param {string} widgetId
     * @param {string} widgetTemplateId
     */
    show = (title,widgetId,widgetTemplateId) => {
        this.Element.classList.add("widget-form-iframe--show");
        if (title) {
            this.Element.querySelector(".widget-form-iframe__header-title").innerHTML = title;
        }
        if (!widgetId || !widgetTemplateId) {
            alert("Teknik bir problem yaşandı lütfen daha sonra tekrar deneyiniz !");
            console.error("Sürüklenen widget settings değerlerine ulaşılamadı !");
        }

        this.setIframeSrc(widgetId, widgetTemplateId);

        document.body.style.overflow = "hidden";
    }

    hide = () => {
        this.Element.classList.remove("widget-form-iframe--show");
        document.body.style.overflow = "auto";
    }
}

window.HelperFunction = new HelperFunction();
window.WidgetFormIframe = new WidgetFormIframe();