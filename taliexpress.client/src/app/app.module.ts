import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
//import { PokemonBaseModule } from './pokemon-base/pokemon-base.module';
//import { PokemonListComponent } from './pokemon-base/pokemon-list/pokemon-list.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { ProductComponent } from './product/product.component'; 
import { TestComponent } from './test/test.component';
import { SharedModulesModule } from './shared-modules/shared-modules.module';


@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    TestComponent,
    //PokemonBaseModule,
  ],
  imports: [
    BrowserModule,
    ProductComponent,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    SharedModulesModule,
    //PokemonListComponent
    //PokemonBaseModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
