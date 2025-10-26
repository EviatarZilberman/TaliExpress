import { Component } from '@angular/core';

interface Pokemon {
  id: number,
  name: string,
  type: string,
  isCool: boolean
}

@Component({
  selector: 'app-pokemon-list',
  templateUrl: './pokemon-list.component.html',
  styleUrls: ['./pokemon-list.component.css'],
  standalone: false
})
export class PokemonListComponent {
  pokemons: Pokemon[] = [
    {
      id: 1,
      name: 'Bulbasaur',
      type: 'Grass/Poison',
      isCool: true
    },
    {
      id: 2,
      name: 'Charmander',
      type: 'Fire',
      isCool: false
    },
    {
      id: 3,
      name: 'Squirtle',
      type: 'Water',
      isCool: true
    },
    {
      id: 4,
      name: 'Pikachu',
      type: 'Electric',
      isCool: true
    },
    {
      id: 5,
      name: 'Eevee',
      type: 'Normal',
      isCool: false
    }]
  constructor() { }
}
