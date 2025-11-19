import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PokemonTemplateFormComponent } from './pokemon-template-form.component';

describe('PokemonTemplateFormComponent', () => {
  let component: PokemonTemplateFormComponent;
  let fixture: ComponentFixture<PokemonTemplateFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PokemonTemplateFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PokemonTemplateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
