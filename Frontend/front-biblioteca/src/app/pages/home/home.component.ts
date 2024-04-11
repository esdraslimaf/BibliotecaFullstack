import { Component } from '@angular/core';
import { authorService } from '../../services/author.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  autores!: any[];

constructor(private authorService: authorService){}

ngOnInit():void{
  this.buscarAutores();
}

buscarAutores() {
  this.authorService.BuscarAutores().subscribe(
    (data: any) => {
      this.autores = data; 
    },
    error => {
      console.log(error);
    }
  );

}
}
