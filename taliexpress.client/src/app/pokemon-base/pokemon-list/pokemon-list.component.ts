///* Services and dependency injection */
//import { Component, OnInit, AfterViewInit, ElementRef, ViewChild, ViewChildren, Renderer2 } from '@angular/core';
//import { Pokemon } from '../../../../Classes/Pokemon';
//import { PokemonService } from '../../services/pokemon-service.service';

//@Component({
//  selector: 'app-pokemon-list',
//  templateUrl: './pokemon-list.component.html',
//  styleUrls: ['./pokemon-list.component.css'],
//  standalone: false
//})
//export class PokemonListComponent implements OnInit, AfterViewInit {
//  pokemons!: Pokemon[]
//  //@ViewChild('pokemonRef') pokemonRef!: ElementRef
//  @ViewChildren('pokemonRef') pokemonRef!: ElementRef
//  @ViewChild('pokemonTh') pokemonTh!: ElementRef
//  constructor(private pokemonService: PokemonService, private renderer: Renderer2)
//  {

//  }

//  ngOnInit(): void {
//    this.pokemonService.getPokemons().subscribe((data: Pokemon[]) => {
//      //console.log(data);
//      this.pokemons = data;
//    });
//  }

//  handleRemove(event: Pokemon) {
//    this.pokemons = this.pokemons.filter((pokemon: Pokemon) => {
//      return pokemon.id !== event.id
//    });
//  }

//  ngAfterViewInit(): void {
//    //console.log(this.pokemonRef);
//    console.log(this.pokemonTh);
//    this.pokemonTh.nativeElement.innerText = "Pokemon name:";
//    const div = this.renderer.createElement('div');
//    const text = this.renderer.createText('Pokemon list');
//    this.renderer.appendChild(div, text);
//    this.renderer.appendChild(this.pokemonTh.nativeElement, div);
//  }
//}
