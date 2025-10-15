import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { UpperNavBarComponent } from './upper-nav-bar/upper-nav-bar.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { ProductComponent } from './product/product.component'; 
import { TestComponent } from './test/test.component'; 

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    UpperNavBarComponent,
    LoginComponent,
    TestComponent
  ],
  imports: [
    BrowserModule,
    ProductComponent,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent] // ✅ only AppComponent here
})
export class AppModule { }
