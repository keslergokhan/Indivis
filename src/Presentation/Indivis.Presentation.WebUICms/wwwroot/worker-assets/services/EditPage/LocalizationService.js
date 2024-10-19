export class LocalizationService {

    constructor() {
        /** @type {Array<Localization>} */
        this.Localizations = []
    }

    /**
     * Yeni localization nesneleri oluştur.
     */
    createLocalizatonObject = () => {
        document.querySelectorAll(".js-cms-loc-key").forEach(loc => {
            this.Localizations.push(new Localization(loc));
        });
    }

    

    executeAsync = async () => {
        this.createLocalizatonObject();
        setTimeout(async () => {
            for (const loc of this.Localizations) {
                await loc.executeAsync();
            }
        }, 1000);
    }
}



class Localization {

    constructor(localizationElement) {
        /** @type {Element} */
        this.LocalizationElement = localizationElement;
    }

    getLocalizationKey = () => {
        return this.LocalizationElement.getAttribute("data-loc-key");
    }

    getLocalizationDbId = () => {
        return this.LocalizationElement.getAttribute("data-loc-id");
    }

    getLocalizationId = () => {
        return this.LocalizationElement.getAttribute("id");
    }
   
    localizationClickHandlerAsync = async () => {
        this.LocalizationElement.addEventListener('click', () => {

        })
    }


    getLocalizationDbDataAsync = async () => {
        fetch(`/api/LocalizationCmsApi/get-localization/${this.getLocalizationKey()}`)
            .then(res => res.json())
            .then(json => {
                if (json.isSuccess) {
                    console.log(json.data);
                }
            })
    }

    getCreateCkEditorObject = (id) => {
        return ClassicEditor
            .create(document.querySelector(`#${id}`), {
                toolbar: [
                    'bold',        // Kalın yazma
                    'italic',      // İtalik yazma
                    'heading'      // Başlıklar (h1-h6)
                ],
                heading: {
                    options: [
                        { model: 'paragraph', title: 'Başlık', class: 'ck-heading_paragraph' },
                        { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                        { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                        { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                        { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                        { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                        { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' }
                    ]
                }
            })
            .catch(error => {
                console.error(error);
            });
    }

    localizationCkEditorHandlerAsync = async () => {
        this.getCreateCkEditorObject(this.getLocalizationId())
    }

    executeAsync = async () => {
        await this.localizationClickHandlerAsync();
        await this.localizationCkEditorHandlerAsync();
        await this.getLocalizationDbDataAsync();
    }
}