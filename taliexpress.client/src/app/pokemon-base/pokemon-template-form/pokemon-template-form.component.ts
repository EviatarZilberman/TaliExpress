import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { PokemonService } from '../../services/pokemon-service.service';
import { Pokemon } from '../../../../Classes/Pokemon';
import { PokemonType } from '../../../../Classes/PokemonType';
import { ActivatedRoute, Router, Params } from '@angular/router';

@Component({
  selector: 'app-pokemon-template-form',
  standalone: false,
  templateUrl: './pokemon-template-form.component.html',
  styleUrl: './pokemon-template-form.component.css'
})
export class PokemonTemplateFormComponent implements OnInit {
  pokemon: Pokemon = {
    id: -1,
    name: '',
    acceptTerms: false,
    isCool: false,
    type: ''
  }
  pokemonTypes: PokemonType[] = [
    {
      key: 1,
      value: "Electric"
    },
    {
      key: 2,
      value: "Fire"
    },
    {
      key: 3,
      value: "Water"
    },
    {
      key: 4,
      value: "Grass"
    },
  ]
  constructor(private pokemonService: PokemonService, private cd: ChangeDetectorRef /* apply changes */, 
 private router: Router, private activatedRoute: ActivatedRoute) { }

  modelChange(object: any) {
    console.log(object);
    this.pokemon.isCool = object;
  }
  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      const id = +params['id']; // convert to number

      this.pokemonService.getPokemon(id).subscribe(p => {
        this.pokemon = p;
        this.cd.detectChanges();
        console.log("Loaded Pokemon:", p);
      });
    });
  }


  //ngOnInit() {
  //  this.pokemon = {} as Pokemon;
  //  this.activatedRoute.params.subscribe((data: Params) => {
  //    this.pokemonService.getPokemon().subscribe((data: Pokemon) => {
  //      this.pokemon = data;
  //    });
  //  });
  //}

  public back(): void {
    this.router.navigate(['/pokemon']);
  }

  addToPokemons(object: any) {
    //let newPokemon: Pokemon = new Pokemon();
    //newPokemon.id = object.id;

    console.log(object);
  }
}
