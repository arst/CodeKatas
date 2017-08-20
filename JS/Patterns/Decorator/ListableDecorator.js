"use strict";
function decoratable(obj, methodName) {
    let original = obj[methodName];
    return function () {
        let value = original.call(obj);
        obj.enlistedDecorators.forEach(function (decoratorName) {
            value = obj.constructor.decorators[decoratorName][methodName](value);
        }, obj);
        return value;
    };
}

function Burger(ingridients) {
    this.ingridients = ingridients || [];
    this.enlistedDecorators = [];
}

Burger.prototype.getRecipe = function getRecipe() {
    return this.ingridients;
};

Burger.prototype.decorate = function decorate(decoratorName) {
    this.enlistedDecorators.push(decoratorName);
};

Burger.decorators = {
    onion: {
        getRecipe: function onion(ingridients) {
            ingridients.push('onions');
            return ingridients;
        }
    },
    cheese: {
        getRecipe: function onion(ingridients) {
            ingridients.push('cheese');
            return ingridients;
        }
    }
};

let burger = new Burger(['bread', 'meat']);
burger.decorate('onion');
burger.decorate('cheese');
burger.getRecipe = decoratable(burger, 'getRecipe');
console.log(burger.getRecipe());


