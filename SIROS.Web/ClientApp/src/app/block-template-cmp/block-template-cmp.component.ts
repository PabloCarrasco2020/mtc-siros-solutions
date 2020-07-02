import { Component, OnInit, Input } from '@angular/core';

@Component({
  template: `
  <div class="block-ui-template text-center text-white " >
    <div class="loader">
    </div>
    <h2 class="text-white">MTC</h2>
    <Label>{{message}}</Label>
  </div>
`
})
export class BlockTemplateCmpComponent {
  @Input() message: string = '';
}
