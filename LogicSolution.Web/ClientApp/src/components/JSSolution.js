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

    render() {
        return (
            <div>
                <h1>Increment String</h1>
                <button onClick={() => this.incrementString('009')} > Click</button>
            </div>
        );
    }
}
