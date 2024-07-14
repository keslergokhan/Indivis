import { JustValidateMessage, HelperFunction  } from '../Helpers/HelperFunctions.js'
import { BaseService } from '../Base/BaseService.js'


export default class LoginService extends BaseService {

    /**
     * 
     * @param {string} formClassName
     * @param {string} path
     */
    constructor(formClassName, path) {
        super(formClassName,path);
    }

    /**
     * 
     * @param {ParentNode} e
     */
    eventHandlerAsync(form) {
    }

    /**
     * 
     * @param {JustValidate} justValidate
     */
    justValidate(justValidate) {

        justValidate
            .addField(`[name="Email"]`, [
                {
                    rule: 'required',
                    errorMessage: JustValidateMessage.required(),
                },
                {
                    rule: "email",
                    errorMessage: JustValidateMessage.email()
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
            ]).addField(`[name="Password"]`, [
                {
                    rule: 'required',
                    errorMessage: JustValidateMessage.required(),
                },
                {
                    rule: 'minLength',
                    value: 6,
                    errorMessage: JustValidateMessage.minLenght(6),
                },
                {
                    rule: 'maxLength',
                    value: 20,
                    errorMessage: JustValidateMessage.maxLenght(20),
                },
            ])
    }


    /**
     * 
     * @param {Event} e
     */
    async submitHandlerAsync(e) {

        const formData = HelperFunction.formDataToJsonObject(new FormData(e.target));

        await fetch(this.Path, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        }).then(res => {
            return res.json();
        }).then(json => {

            if (json.isSuccess == true) {

                window.location.pathname = "/home/index";
            } else {
                alert("Kullanıcı adı veya şifre yanlış");
            }
            console.log(json);
        })
    }


    
}



