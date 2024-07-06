
export default {


    
    /**
     * formdata elemanlarını key:value şeklinde object dönüştürür
     * @param {FormData} formData
     * @return {object}
     */
    formDataToJsonObject:(formData) => {
        var jsonObject = {};
        formData.forEach(function (value, key) {
            jsonObject[key] = value;
        });

        return jsonObject;
    }
}