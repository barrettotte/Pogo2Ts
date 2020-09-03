import { Thing } from './Thing'

export class Address extends Thing{
  line1?: string;
  line2?: string;
  city?: string;
  state?: string;
  zip?: string;
}
