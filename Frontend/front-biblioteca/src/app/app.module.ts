import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { CadastroComponent } from './pages/cadastro/cadastro.component';
import { AuthorFormComponent } from './components/author-form/author-form.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CadastroComponent,
    AuthorFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
