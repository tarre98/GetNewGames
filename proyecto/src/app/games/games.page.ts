import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastController } from '@ionic/angular';
import axios from 'axios';

@Component({
  selector: 'app-games',
  templateUrl: './games.page.html',
  styleUrls: ['./games.page.scss'],
})
export class GamesPage implements OnInit {

  userid
  envio = ""
  Games = [];
  titulo
  idLibro
  editorial
  categoria
  lugarRecogida
  propietario
  tituloInput
  editorialInput
  categoriaInput
  lugarRecogidaInput
  propietarioInput
  idLibroInput
  key
  cargado = false
  visibleInput = false
  visibleMenu = true
  visibleUpdate = false
  useridFilter
  categoriaFilter
  booksMine = false
  contador: number;
  Game: any;
  nameInput: any;
  visibleDetails: boolean;
  cantidad: any;
  errorMessage: string
  isAdmin1: any;
  userLogin: any;
  useridLogin: any;
  plataformaInput: string;

  constructor(private _toastCtrl: ToastController, private _activateRoute: ActivatedRoute) {


  }

  ngOnInit() {
    this.allBooks()
    this.userid = this._activateRoute.snapshot.paramMap.get('useridInput');


  }

  updateBook(key) {


    this.Games.forEach(libro => {
      if (libro.key == key) {


        this.titulo = libro.titulo
        this.idLibro = libro.idLibro
        this.categoria = libro.categoria
        this.editorial = libro.editorial
        this.propietario = libro.propietario
        this.lugarRecogida = libro.lugar_Recogida
        console.log(this.titulo)

      }
    })
    this.visibleMenu = false;
    this.visibleUpdate = true;


    console.log("he entrado")

  }

  changeVisibilityMenuInput() {


    this.visibleInput = true;
    this.visibleMenu = false;
    if (this.visibleMenu == false) {
      this.visibleInput = false;
      this.visibleMenu = true;
      location.reload();
    }
    this.contador++



  }

  async nameFilter(){
    this.Games=[]
    try {
      const response = await axios.get("https://localhost:44303/api/GamesName/Get/"+this.nameInput, { headers: { 'Access-Control-Allow-Origin': '' } });

      console.log(response.data);
      response.data.forEach(element => {
        this.Games.push(element)
      });



      } catch (error) {
        console.error(error);
      }



  } 
  async plataformaFilter(){
    this.Games=[]
    console.log("https://localhost:44303/api/GamesPlataform/Get/"+this.plataformaInput);
    try {
      const response = await axios.get("https://localhost:44303/api/GamesPlataform/Get/"+this.plataformaInput, { headers: { 'Access-Control-Allow-Origin': '' } });
      console.log(response.data);
      response.data.forEach(element => {
        this.Games.push(element)
      });




      } catch (error) {
        console.error(error);
      }



  }


  async allBooks() {
    this.booksMine = false;
    this.Games = []
    try {
      const response = await axios.get("https://localhost:44303/api/User/Getgame", { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      response.data.forEach(element => {
        this.Games.push(element)
      });

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

  async gameDetail(gameID) {
    this.visibleDetails = true
    this.visibleMenu = false
    try {
      const response = await axios.get("https://localhost:44303/api/Games/Get/" + gameID, { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      this.Game = response.data
      response.data.forEach(element => {
        this.Game = element
      });

    } catch (error) {
      console.error(error);
    }
    console.log(this.Game);



  }


  
  async makePurchaseNacional() {
    this.envio = "Nacional"
    if (this.cantidad == null) {
      this.errorMessage = "has de introducir una cantidad"
      this.presentToast()

    } else {
      console.log({

        "idsale": 1,
        "iduser": this.userid,
        "idgame": this.Game.idgames,
        "precio": this.Game.precio,
        "envio": this.envio,
        "cantidad": this.cantidad


      });
      
      try {
        const response = await axios.get("https://localhost:44303/api/User/Get/" + this.userid, { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      this.userLogin = response.data
      response.data.forEach(element => {
        this.userLogin = element
      });
      this.useridLogin = this.userLogin.userId

        await axios.post("https://localhost:44303/api/Sale/post", {

          "idsale": 1,
          "iduser": this.useridLogin,
          "idgame": this.Game.idgames,
          "precio": this.Game.precio,
          "envio": this.envio,
          "cantidad": this.cantidad


        }, { headers: { 'Access-Control-Allow-Origin': '*' } });
        this.errorMessage = "Compra Realizada"
        this.presentToast()
        this.visibleDetails = false
        this.visibleMenu = true

      } catch (error) {
        console.error(error);
      }
    }
  }

  async makePurchaseInternacional() {
    this.envio = "Internacional"
    if (this.cantidad == null) {
      this.errorMessage = "has de introducir una cantidad"
      this.presentToast()

    }
    else {
      const response = await axios.get("https://localhost:44303/api/User/Get/" + this.userid, { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      this.userLogin = response.data
      response.data.forEach(element => {
        this.userLogin = element
      });
      this.useridLogin = this.userLogin.userId
      try {

        await axios.post("https://localhost:44303/api/Sale/post", {

          "idsale": 1,
          "iduser": this.useridLogin,
          "idgame": this.Game.idgames,
          "precio": this.Game.precio,
          "envio": this.envio,
          "cantidad": this.cantidad

        }, { headers: { 'Access-Control-Allow-Origin': '*' } });
        this.errorMessage = "Compra Realizada"
        this.presentToast()
        this.visibleDetails = false
        this.visibleMenu = true



      } catch (error) {
        console.error(error);
      }
    }


  }


}
