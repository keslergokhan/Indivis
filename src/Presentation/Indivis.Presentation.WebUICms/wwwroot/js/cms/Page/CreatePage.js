import { HelperFunction, JustValidateMessage } from '../Helpers/HelperFunctions.js'
import { BaseService } from '../Base/BaseService.js'

export default class CreatePageService extends BaseService {


    /**
     * 
     * @param {string} formClassName
     * @param {string} path
     */
    constructor(formClassName, path) {
        super(formClassName, path);
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
            .addField(`[name="Slug"]`, [
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

        form.querySelector(`[name="Slug"]`).addEventListener('keydown', (e) => {

            let newKey = HelperFunction.translateTextToSlug(e.target.value);
            const parentUrl = e.target.getAttribute("data-parent-url");

            if (parentUrl && parentUrl != "" && !e.target.value.startsWith(parentUrl)) {
                newKey = HelperFunction.translateTextToSlug(parentUrl + "/" + e.target.value);
            }

            e.target.value = newKey;
            
        });


        form.querySelector(`[name="Slug"]`).addEventListener('keyup', (e) => {
            console.log("a");
        })
    }

    /**
     * 
     * @param {Event} e
     */
    async submitHandlerAsync(e) {
        const formData = HelperFunction.formDataToJsonObject(new FormData(e.target));

        await fetch(this.Path, {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        }).then(res => {
            //return res.json();
        }).then(json => {

            
        })
    }
}