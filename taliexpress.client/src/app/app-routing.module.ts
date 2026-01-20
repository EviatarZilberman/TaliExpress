import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProductComponent } from './product/product.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ErrorComponent } from './error/error.component';
import { PersonalAreaComponent } from './personal-area/personal-area.component';
//import { PokemonTemplateFormComponent } from './pokemon-base/pokemon-template-form/pokemon-template-form.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: "full" },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'product', component: ProductComponent },
  { path: 'personal_area', component: PersonalAreaComponent },
  //{ path: 'pokemon/:id', component: PokemonTemplateFormComponent },
  //{
  //  path: 'pokemon', loadChildren:
  //    () => import('./pokemon-base/pokemon-base.module')
  //    .then(m => m.PokemonBaseModule)
  //},
  //,
  //{ path: 'users/:id/:aaa', component: UsersComponent, data:  }
  { path: 'error', component: ErrorComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
