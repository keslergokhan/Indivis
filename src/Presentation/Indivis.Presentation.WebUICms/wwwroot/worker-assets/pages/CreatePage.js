﻿import CreatePageService from "../services/CreatePageService";

const createPageService = new CreatePageService(".create-page-from", "/api/PageCmsApi");
createPageService.executeAsync();