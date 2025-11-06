import { Component, OnInit } from '@angular/core';
import { PokemonService } from '../services/pokemon-service.service';
import { Pokemon } from '../../../Classes/Pokemon';

@Component({
  selector: 'app-pokemon-template-form',
  standalone: false,
  templateUrl: './pokemon-template-form.component.html',
  styleUrl: './pokemon-template-form.component.css'
})
export class PokemonTemplateFormComponent implements OnInit {
  pokemon!: Pokemon;
  constructor(private pokemonService: PokemonService) { }

  modelChange(object: any) {
    console.log(object);
    this.pokemon.isCool = object;
  }

  ngOnInit() {
    this.pokemonService.getPokemon(1).subscribe((data: Pokemon) => {
      this.pokemon = data;
    });
  }
}
