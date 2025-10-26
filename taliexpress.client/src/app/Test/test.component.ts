import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css'],
  standalone: false
})

export class TestComponent implements OnInit {
  var1: number = 1;
  var2: number = 2;
  title: string = 'TestComponent';
  imageUrl: string = 'https://ae01.alicdn.com/kf/Sd2e8f3f3e8f14b1fa6b3f2a1c6c1e8e4D/LED-Strip-Lights-5M-10M-15M-20M-30M-RGB-5050-SMD-Flexible-LED-Light-Strip-Non-waterproof.jpg_Q90.jpg_.webp';
  favoriteAnimal: string = 'Turtle'
  pokemonName: string = '';
 


  constructor() {
  }

  public handleClick(pokemonName: string): void {
    alert(pokemonName);
  }

  public handleChange(event: any): void {
    this.pokemonName = event.target.value;
  }

  ngOnInit(): void {
  }
}
