import { NameIdPair } from './nameIdPair';

export interface FeaturesPrice {
  id: number;
  hallPrice: number;
  cateringPrice: number;
  banjoPrice: number;
  flowerPrice: number;
  hallOwner: NameIdPair;
}
