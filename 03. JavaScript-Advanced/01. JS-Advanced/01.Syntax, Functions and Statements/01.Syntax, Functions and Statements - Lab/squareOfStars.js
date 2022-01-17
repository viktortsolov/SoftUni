function solve(param = 5) {
    let result = new Array(param);

    for (let i = 0; i < param; i++) {
        result[i] = "* ".repeat(param).trim();
    }
    return result.join("\n");
}