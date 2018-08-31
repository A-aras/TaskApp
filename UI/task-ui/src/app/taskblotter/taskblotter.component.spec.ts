import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskblotterComponent } from './taskblotter.component';

describe('TaskblotterComponent', () => {
  let component: TaskblotterComponent;
  let fixture: ComponentFixture<TaskblotterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskblotterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskblotterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
