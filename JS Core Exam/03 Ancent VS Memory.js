function solve(input) {
    let string = input.join(' ');
    let arr = string.split(' ').map(a => Number(a));
    let result = [];
    let words = [];
    for (let i = 0; i < arr.length; i++) {
        if(arr[i] === 32656 && arr[i+1] === 19759 && arr[i+2] === 32763) {
            let arrResult =[];
            let letterCounter = arr[i+4];
            let num = i+6;
            letterCounter += num;
            for(let j = num; j < letterCounter; j++) {
                arrResult.push(arr[j]);
            }
            result.push(arrResult)
        }
    }
    for (let name of result) {
        let letters = '';
        for (let i = 0; i < name.length; i++) {
            letters += String.fromCharCode(name[i]);
        }
        words.push(letters);
    }
    let final = words.join('\n');
    console.log(final.trim());
}