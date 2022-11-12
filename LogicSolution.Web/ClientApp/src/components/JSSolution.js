import React, { Component } from 'react';

export class JSSolution extends Component {
    static displayName = JSSolution.name;

    incrementString(strng) {
        var idxNum = 0;
        var found = false;
        for (var i = strng.length - 1; i >= 0 && !found; i--) {
            if (isNaN(strng[i])) {
                found = true;
                idxNum = i + 1;
            }
        }

        var newNum = parseInt(strng.substring(idxNum)) + 1;
        newNum = isNaN(newNum) ? 1 : newNum;
        var offset = strng.substring(idxNum).length - newNum.toString().length;
        var newOffsetNum = strng.slice(idxNum, idxNum + offset) + newNum;
        alert(strng.substring(0, idxNum) + newOffsetNum);
    }

    titleCase(title, minorWords) {
        var first = true; 
        alert(title.split(" ").map(x => {
            if (first || minorWords == null || !minorWords.split(" ").some(y => y.toUpperCase() == x.toUpperCase())) {
                first = false;
                return x[0].toUpperCase().concat(x.substring(1).toLowerCase());
            } else {
                return x.toLowerCase();
            }
        }).join(" "));
    }

    moveZeros(arr) {
        var arrNonZero = arr.filter(x => x !== 0);
        var arrZero = arr.filter(x => x === 0);
        alert(arrNonZero.concat(arrZero));
    }

    render() {
        return (
            <div>
                <div>
                    <h1>Increment String</h1>
                    <button onClick={() => this.incrementString('009')} > Click</button>
                </div>
                <div>
                    <h1>Title Case</h1>
                    <button onClick={() => this.titleCase('the quick brown fox')} > Click</button>
                </div>
                <div>
                    <h1>Move Zeroes</h1>
                    <button onClick={() => this.moveZeros([1, 2, 0, 1, 0, 1, 0, 3, 0, 1])} > Click</button>
                </div>
            </div>
        );
    }
}
