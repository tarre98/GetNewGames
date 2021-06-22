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

  //declarar variables
//  #region

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
  dineroGastado: any;

 // #endregion

  constructor(private _toastCtrl: ToastController, private _activateRoute: ActivatedRoute) {


  }

  ngOnInit() {
    //traemos todos los libros y el id de user (por la url)
    this.allBooks()
    this.userid = this._activateRoute.snapshot.paramMap.get('useridInput');


  }


  // FILTRO POR NOMBRE
  async nameFilter(){
    //declaramos lista vacia
    this.Games=[]
    try {
      //await(en funcion) = async (en clase)
      //axios = libreria para conexion con sql
      // filtro donde con la url + el input para buscar, y el header siempre es el mismo (abre puertas para que se conecte cualquier como en clase)
      const response = await axios.get("https://localhost:44303/api/GamesName/Get/"+this.nameInput, { headers: { 'Access-Control-Allow-Origin': '' } });

      console.log(response.data);
      //todos los juegos con ese nombre los guarda en la lista de games para mostrar
      response.data.forEach(element => {
        this.Games.push(element)
      });



      } catch (error) {
        console.error(error);
      }



  } 

  // FILTRO POR PLATAFORMA
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

  //filtro para hacer un get de todo
  async allBooks() {
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

  //TOAST
  async presentToast() {
    const toast = await this._toastCtrl.create({
      message: this.errorMessage,
      duration: 3000,
      position: 'bottom'

    });
    toast.present();

  }

  // filtro por nombre del juego, para ver sus detalles
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


  // hacer  la compra es nacional
  async makePurchaseNacional() {
    this.envio = "Nacional"
    // si los campos vicios , no funciona
    if (this.cantidad == null) {
      this.errorMessage = "has de introducir una cantidad"
      this.presentToast()
      // si..
    } else {
      console.log({

        "idsale": 1,
        "iduser": this.userid,
        "idgame": this.Game.idgames,
        "precio": this.Game.precio,
        "envio": this.envio,
        "cantidad": this.cantidad


      });
      
      //me conecto al usuario que esta logeado
      try {
        const response = await axios.get("https://localhost:44303/api/User/Get/" + this.userid, { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      this.userLogin = response.data
      response.data.forEach(element => {
        this.userLogin = element
      });
      //guardamos variables de bd a local
      this.useridLogin = this.userLogin.iduser
      this.dineroGastado = this.userLogin.dineroGastado
      
      // post donde agregamos la nueva compra 
        await axios.post("https://localhost:44303/api/Sale/Post", {

          "idsale": 1,
          "iduser": this.useridLogin,
          "idgame": this.Game.idgames,
          "precio": this.Game.precio,
          "envio": this.envio,
          "cantidad": this.cantidad


        }, { headers: { 'Access-Control-Allow-Origin': '*' } });
        console.log("https://localhost:44303/api/User/Put/"+((this.cantidad*this.Game.precio)+this.dineroGastado)+"/"+this.useridLogin);
        
        // para comprobar el dinero gastado,ya que varia si es envio internacional o nacional
        axios.get("https://localhost:44303/api/User/Put/"+((this.cantidad*this.Game.precio)+this.dineroGastado)+"/"+this.useridLogin,{ headers: { 'Access-Control-Allow-Origin': '*' }})
        this.errorMessage = "Compra Realizada"
        this.presentToast()
        this.visibleDetails = false
        this.visibleMenu = true

      } catch (error) {
        console.error(error);
      }
    }
  }

  // LO MISMO, PERO ENVIO INTERNACIONAL
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
