import { NgModule, APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { PokemonBaseModule } from './pokemon-base/pokemon-base.module';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { ProductComponent } from './product/product.component'; 
import { TestComponent } from './test/test.component';
import { SharedModulesModule } from './shared-modules/shared-modules.module';
import { ConfigurationService } from '../../Services/ConfigurationService';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { CustomifDirective } from './directives/customif/customif.directive';
import { HighlighttextDirective } from './directives/highlighttext/highlighttext.directive';
//import { PokemonTemplateFormComponent } from './pokemon-template-form/pokemon-template-form.component';

export function initConfig(configService: ConfigurationService) {
  return () => configService.loadConfig();
}

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    TestComponent,
    HomeComponent,
    NotFoundComponent,
    CustomifDirective,
    HighlighttextDirective,
    //PokemonTemplateFormComponent
  ],
  imports: [
    BrowserModule,
    ProductComponent,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    SharedModulesModule,
    PokemonBaseModule,
  ],
  providers: [
    {
    provide: APP_INITIALIZER,
    useFactory: initConfig,
      deps: [ConfigurationService],
    multi: true
    }],
  bootstrap: [AppComponent,
    HighlighttextDirective,
    CustomifDirective
  ]
})
export class AppModule { }
