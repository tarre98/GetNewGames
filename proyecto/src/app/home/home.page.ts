import { Component } from '@angular/core';
import { ToastController } from '@ionic/angular';
import axios from 'axios';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  //declaramos variables
  useridInput: string;
  isAdmin: boolean;
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
  apellidoRegistro: any;
  emailRegistro: any;
  edadRegistro: any;
  numcuentaRegistro: any;
  constructor(private _toastCtrl: ToastController) { }


// leemos usuario, y traemos el usuario
  ngOnInit() {
    console.log("https://localhost:44303/api/User/Get")
    this.getUsers()
  }

  //get all
  async getUsers() {
    try {
      const response = await axios.get("https://localhost:44303/api/User/Get", { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      this.Users.push(response.data)
    } catch (error) {
      console.error(error);
    }
  }

  //toast incorrecto
  async presentToast() {
    const toast = await this._toastCtrl.create({
      message: this.errorMessage,
      duration: 3000,
      position: 'bottom'

    });
    toast.present();

  }

  //toast correcto
  async CorrectToast() {
    const toast = await this._toastCtrl.create({
      message: 'Login Correcto',
      duration: 3000,
      position: 'bottom'

    });
    toast.present();

  }

  // funcion para logearte
  async matchLogin() {
    console.log("https://localhost:44303/api/User/log/" + this.useridInput + "/" + this.pwdInput)

    // si estan bien el usuario y contraseña , recoge datos y avanza
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
        //guardo en local si es admin
        this.isAdmin = this.userLogin.admin
        console.log(this.isAdmin);



      }
    } catch (error) {

      console.error(error);
    }

  }

  //funcion para ver el registro si le da al boton
  registroVisibility() {

    this.registro = true;
    this.login = false;


  }

  //funcion para insertar usuarios en el registro
  async insertUser(){


    if( this.userIdRegistro==null || this.pwdRegistro==null ||this.nombreRegistro==null ||this.apellidoRegistro==null ||this.emailRegistro==null ||this.edadRegistro==null ||this.numcuentaRegistro==null){
      this.errorMessage = "Falta algun campo"
        this.presentToast()
    }else{
      console.log({"iduser":this.userIdRegistro,
          "name": this.nombreRegistro,
          "pasword": this.pwdRegistro,
          "admin": this.admin,
          "apellido": this.apellidoRegistro,
          "email": this.emailRegistro,
          "edad":  this.edadRegistro,
          "numCuenta": this.numcuentaRegistro,
          "dineroGastado": 0.0});
      
      try {
        //aqui el post para subirlo a la base de datos
        await axios.post("https://localhost:44303/api/User/post", {
  
          "iduser":this.userIdRegistro,
          "name": this.nombreRegistro,
          "pasword": this.pwdRegistro,
          "admin": this.admin,
          "apellido": this.apellidoRegistro,
          "email": this.emailRegistro,
          "edad":  this.edadRegistro,
          "numCuenta": this.numcuentaRegistro,
          "dineroGastado": 0.0
  
        }, { headers: { 'Access-Control-Allow-Origin': '*' } });
        this.errorMessage = "Registro Realizada"
        this.presentToast()
        location.reload()
  
  
      } catch (error) {
        console.error(error);
      }
    }
  }
  //si se hace boton makeadmin le hace admin, ya q en la base de datos se define por 1 o 0, no por true o false (bool)
  makeAdmin(){
    this.admin=1
    this.errorMessage = "Es Admin"
    this.presentToast()
  } 
  
  // "" "" ""  no se hace admin
  makeNoAdmin(){
    this.admin=0
    this.errorMessage = "No es Admin"
    this.presentToast()
  }


}