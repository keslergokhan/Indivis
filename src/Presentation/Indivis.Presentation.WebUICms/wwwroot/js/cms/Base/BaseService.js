export class BaseService {
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
    submitHandler(e) {
        throw new Error("Lütfen submitHandler override ediniz !");
    }


    execute() {
        document.querySelector(this.FormClassName).addEventListener('submit', (e) => {
            e.preventDefault();

            this.validation(e);
            this.submitHandler(e);
        });
    }
}