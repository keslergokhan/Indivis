import LoginService from '../services/account/LoginService.js'

const loginService = new LoginService(".login-form", "/api/accountApi");
loginService.executeAsync();