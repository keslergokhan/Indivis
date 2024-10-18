import { JustValidateMessage,HelperFunction } from '../helpers/HelperFunctions.js'
import { BaseService } from '../base/BaseService.js'

export default class CreatePageService extends BaseService {


    /**
     * 
     * @param {string} formClassName
     * @param {string} basePath
     */
    constructor(formClassName, basePath) {
        super(formClassName, basePath);
    }

    /**
     * 
     * @param {JustValidate} justValidate
     */
    justValidate(justValidate) {

        justValidate
            .addField(`[name="Name"]`, [
                {
                    rule: 'required',
                    errorMessage: JustValidateMessage.required(),
                },
                {
                    rule: 'minLength',
                    value: 3,
                    errorMessage: JustValidateMessage.minLenght(3),
                },
                {
                    rule: 'maxLength',
                    value: 20,
                    errorMessage: JustValidateMessage.maxLenght(20),
                },
            ])
            .addField(`[name="FullPath"]`, [
                {
                    rule: "required",
                    errorMessage: JustValidateMessage.required(),
                },
                {
                    rule: 'minLength',
                    value: 3,
                    errorMessage: JustValidateMessage.minLenght(3),
                }
            ])
    }

    /**
     * 
     * @param {ParentNode} e
     */
    async eventHandlerAsync(form) {

        const path = document.querySelector(`[name="Path"]`);
        form.querySelector(`[name="FullPath"]`).addEventListener('keyup', (e) => {

            let newKey = HelperFunction.translateTextToSlug(e.target.value);
            const parentUrl = e.target.getAttribute("data-parent-url");

            if (parentUrl && parentUrl != "" && !e.target.value.startsWith(parentUrl)) {
                newKey = HelperFunction.translateTextToSlug(parentUrl + "/" + e.target.value);
            }

            e.target.value = newKey;
            path.value = newKey.substr(parentUrl.length);
        });
        
    }

    /**
     * 
     * @param {Event} e
     */
    async submitHandlerAsync(e) {
        const formData = HelperFunction.formDataToJsonObject(new FormData(e.target));


        let fullPathFoundControl = false;
        await fetch(`${this.BasePath}/check-url-full-path`, {
            method: "POST",
            headers: {
                "Content-Type":"application/json"
            },
            body: JSON.stringify({ FullPath: formData.FullPath })
        })
        .then(data => data.json())
        .then(json => {
            if (json.isSuccess) {
                if (json.data.fullPathFound) {
                    fullPathFoundControl = true;
                    Swal.fire({
                        title: "Hata",
                        html: `<strong>${formData.FullPath} </strong> zaten kullanılıyor lütfen farklı bir adres belirleyin`,
                        icon: "error"
                    });

                } else {
                    fullPathFoundControl = false;
                }


            } else {
                this.errorSwal();
                fullPathFoundControl = true;
            }
           
        })
        .catch(x => {
            console.log(x);
            this.errorSwal();
            fullPathFoundControl = true;
        })

        if (fullPathFoundControl) {
            return;
        }

        await fetch(`${this.BasePath}/create-page`, {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        }).then(res => {
            return res.json();
        }).then(json => {
            console.log(json);
        })
    }
}