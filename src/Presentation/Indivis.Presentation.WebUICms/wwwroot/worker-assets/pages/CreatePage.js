import CreatePageService from "../services/CreatePage/CreatePageService.js";

const createPageService = new CreatePageService(".create-page-from", "/api/PageCmsApi");
createPageService.executeAsync();