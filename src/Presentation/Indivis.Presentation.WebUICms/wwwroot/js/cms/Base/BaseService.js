﻿export class BaseService {
    /**
     * 
     * @param {string} formClassName
     * @param {string} path
     */
    constructor(formClassName, path) {
        this.FormClassName = formClassName;
        this.Path = path;
    }

    /**
     * doğrulama süreci
     * @param {Event} e
     */
    validation(e) {
        throw new Error("Lütfen validation override ediniz !");
    }


    /**
     * Form gönderimi
     * @param {Event} e
     */
    async submitHandlerAsync(e) {
        throw new Error("Lütfen submitHandler override ediniz !");
    }


    async executeAsync() {
        const $this = this;
        document.querySelector(this.FormClassName).addEventListener('submit', async (e) => {
            e.preventDefault();

            $this.validation(e);
            await $this.submitHandlerAsync(e);
        });
    }
}