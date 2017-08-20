'use strict';

function Burger(ingridients) {
  this.ingridients = ingridients;
}
Burger.prototype.cook = function cook() {
  this.ingridients.forEach(function (ingridient) {
    console.log(`I'm adding ${ingridient} to the burger`);
  });
}

Burger.prototype.decorate = function decorate(decoratorName) {
  let FakeConstructor = function fakeConstructor() { },
    decorator = this.constructor.decorators[decoratorName];
  FakeConstructor.prototype = this;
  let decorated = new FakeConstructor();
  decorated.uber = this;
  Object.getOwnPropertyNames(decorator).forEach(function (prop) {
    decorated[prop] = decorator[prop];
  });
  return decorated;
}
Burger.decorators = {};

Burger.decorators.onionable = {
  cook: function cook() {
    this.uber.cook();
    console.log("And I'm adding onion to the burger");
  }
}

Burger.decorators.doubleCheezable = {
  cook: function cook() {
    this.uber.cook();
    console.log("And I'm adding cheeze to the burger");
    console.log("And cheeze again");
  }
}

var baseBurger = new Burger(['bread', 'meat', 'cucumber']);
var withOnion = baseBurger.decorate('onionable');
var withDoubleCheeze = baseBurger.decorate('doubleCheezable');
withDoubleCheeze.cook();


