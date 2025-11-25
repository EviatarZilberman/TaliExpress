import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { PokemonTemplateFormComponent } from './pokemon-base/pokemon-template-form/pokemon-template-form.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: "full" },
  { path: 'login', component: LoginComponent },
  { path: 'pokemon/:id', component: PokemonTemplateFormComponent },
  //{
  //  path: 'pokemon', loadChildren:
  //    () => import('./pokemon-base/pokemon-base.module')
  //    .then(m => m.PokemonBaseModule)
  //},
  { path: 'register', component: RegisterComponent },
  //,
  //{ path: 'users/:id/:aaa', component: UsersComponent, data:  }
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
