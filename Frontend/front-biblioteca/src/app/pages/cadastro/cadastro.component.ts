import { Component } from '@angular/core';
import { Author } from '../../models/author';
import { authorService } from '../../services/author.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.scss'
})


export class CadastroComponent {

BtnAcao = "Cadastrar"
BtnTitulo = "Cadastrar Autor"

constructor(private authorService:authorService, private router:Router) {}

createAuthor(authorEntity: Author) {
this.authorService.CadastrarAutor(authorEntity).subscribe(
  sucess=>{
  this.router.navigate(['home'])
  },
  error =>{
  }
)
}

}
