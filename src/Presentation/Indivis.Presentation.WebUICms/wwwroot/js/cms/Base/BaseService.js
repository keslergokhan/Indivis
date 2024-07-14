export class BaseService {
    /**
     * @param {JustValidate}
     * @param {string} formClassName
     * @param {string} path
     */
    constructor(formClassName, path) {
        this.FormClassName = formClassName;
        this.Path = path;
        this.JustValidate;
        
    }



    /**
     * doğrulama süreci
     * @param {JustValidate} justValidate
     */
    justValidate(justValidate) {
        throw new Error("Lütfen validation override ediniz !");
    }


    /**
     * Form gönderimi
     * @param {Event} e
     */
    async submitHandlerAsync(e) {
        throw new Error("Lütfen submitHandler override ediniz !");
    }

    /**
     * 
     * @param {ParentNode} e
     */
    async eventHandlerAsync(form) {
        throw new Error("Lütfen eventHandler override ediniz !");
    }


    async executeAsync() {

        const $this = this;
        
        document.addEventListener('DOMContentLoaded', async function () {
            const form = document.querySelector($this.FormClassName);

            //yapılması gereken iş
            await $this.eventHandlerAsync(form);

            
            //justvalidate
            $this.JustValidate = new JustValidate($this.FormClassName);
            $this.justValidate($this.JustValidate);

            form.addEventListener('submit', async (e) => {
                e.preventDefault();

                if ($this.JustValidate.isValid) {
                    await $this.submitHandlerAsync(e);
                }
                
            });
        });
        
    }
}