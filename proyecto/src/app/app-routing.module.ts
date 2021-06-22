import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';


//rutas para acceder a las clases, pasando parametros , 
const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then( m => m.HomePageModule)
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    //pasamos parametro useridinput
    path: 'games/:useridInput',
    loadChildren: () => import('./games/games.module').then( m => m.GamesPageModule)
  },
  {
        //pasamos parametro si es admin
    path: 'sales/:isAdmin',
    loadChildren: () => import('./sales/sales.module').then( m => m.SalesPageModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
