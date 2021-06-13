import { Component } from '@angular/core';
import { ToastController } from '@ionic/angular';
import axios from 'axios';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {


  useridInput: string;
  isAdmin: any;
  useridPass: string;
  pwdInput: string;
  match = false
  errorMessage: string;
  registro = false
  login = true
  userIdRegistro: string;
  pwdRegistro: string;
  preferenciasRegistro: string;
  nombreRegistro: string;
  tlfRegistro: number;
  apiURL = 'https://localhost:44303/';
  Users = [];
  userLogin: any;
  admin=0;
  constructor(private _toastCtrl: ToastController) { }

  ngOnInit() {
    console.log("https://localhost:44303/api/User/Get")
    this.getUsers()
  }
  async getUsers() {
    try {
      const response = await axios.get("https://localhost:44303/api/User/Get", { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      this.Users.push(response.data)
    } catch (error) {
      console.error(error);
    }
  }
  async presentToast() {
    const toast = await this._toastCtrl.create({
      message: this.errorMessage,
      duration: 3000,
      position: 'bottom'

    });
    toast.present();

  }
  async CorrectToast() {
    const toast = await this._toastCtrl.create({
      message: 'Login Correcto',
      duration: 3000,
      position: 'bottom'

    });
    toast.present();

  }
  async matchLogin() {
    console.log("https://localhost:44303/api/User/log/" + this.useridInput + "/" + this.pwdInput)

    try {
      const response = await axios.get("https://localhost:44303/api/User/log/" + this.useridInput + "/" + this.pwdInput, { headers: { 'Access-Control-Allow-Origin': '*' } });
      if (response.data == true) {
        const response = await axios.get("https://localhost:44303/api/User/Get/" + this.useridInput, { headers: { 'Access-Control-Allow-Origin': '*' } });
        response.data.forEach(element => {
          this.userLogin = element
        });
        this.match = true
        this.useridPass = this.useridInput
        console.log(this.userLogin.admin);

        this.isAdmin = this.userLogin.admin
        console.log(this.isAdmin);



      }
    } catch (error) {

      console.error(error);
    }

  }

  registroVisibility() {

    this.registro = true;
    this.login = false;


  }
  async insertUser(){
    if( this.userIdRegistro==null || this.pwdRegistro==null ||this.nombreRegistro==null){
      this.errorMessage = "Falta algun campo"
        this.presentToast()
    }else{
      try {

        await axios.post("https://localhost:44303/api/User/post", {
  
          "iduser": this.userIdRegistro,
          "name": this.nombreRegistro,
          "pasword": this.pwdRegistro,
          "admin": this.admin
  
        }, { headers: { 'Access-Control-Allow-Origin': '*' } });
        this.errorMessage = "Registro Realizada"
        this.presentToast()
        location.reload()
  
  
      } catch (error) {
        console.error(error);
      }
    }
   






  }
  makeAdmin(){
    this.admin=1
    this.errorMessage = "Es Admin"
    this.presentToast()
  } 
  
  makeNoAdmin(){
    this.admin=0
    this.errorMessage = "No es Admin"
    this.presentToast()
  }


}