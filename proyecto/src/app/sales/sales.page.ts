import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import axios from 'axios';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.page.html',
  styleUrls: ['./sales.page.scss'],
})


export class SalesPage implements OnInit {

  //declaramos variables
  isAdmin1: any;
  userIdInput
  sales = []
  envioInput: string;
  precioInputInicial: string;
  precioInputFinal: string;

  constructor(private _activateRoute: ActivatedRoute) { }

  ngOnInit() {
    //recoge dato de si es admin o no, para acceder a ver la info
    // recoge todas las ventas
    this.isAdmin1 = this._activateRoute.snapshot.paramMap.get('isAdmin');
    console.log(this.isAdmin1);
    this.allBooks()

  }

  //get de todas las ventas
  async allBooks() {
    try {
      const response = await axios.get("https://localhost:44303/api/Sale/Get", { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      response.data.forEach(element => {
        this.sales.push(element)
      });

    } catch (error) {
      console.error(error);
    }

  }

  //filtro para buscar por userid 
  async userIdFilter() {
    this.sales = []
    try {
      const response = await axios.get("https://localhost:44303/api/Sale/Get/User/" + this.userIdInput, { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      response.data.forEach(element => {
        this.sales.push(element)
      });
      console.log(this.sales)

    } catch (error) {
      console.error(error);
    }



  }

  //filtro para buscar si es nacional
  async EnvioNacionalFilter() {
    this.sales = []

    try {
      const response = await axios.get("https://localhost:44303/api/Sale/GetN", { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      response.data.forEach(element => {
        this.sales.push(element)
      });

    } catch (error) {
      console.error(error);
    }



  }

  //filtro para buscar si es internacional
  async EnvioInternacionalFilter() {
    this.sales = []

    try {
      const response = await axios.get("https://localhost:44303/api/Sale/GetI", { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      response.data.forEach(element => {
        this.sales.push(element)
      });

    } catch (error) {
      console.error(error);
    }



  }

  //filtro para buscar por precio
  async PriceFilter() {
    this.sales = []

    try {
      const response = await axios.get("https://localhost:44303/api/Sale/Get/Precio/"+this.precioInputInicial+"/"+this.precioInputFinal, { headers: { 'Access-Control-Allow-Origin': '*' } });
      console.log(response.data);
      response.data.forEach(element => {
        this.sales.push(element)
      });

    } catch (error) {
      console.error(error);
    }



  }

  //recarga pagina
  reloadPage(){
    location.reload()
  }

}