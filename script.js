var currentPlayer = 'X';
var gameEnded = false;
var board = ['', '', '', '', '', '', '', '', ''];

function makeMove(index) {
    if (board[index] === '' && !gameEnded) {
        board[index] = currentPlayer;
        document.getElementsByClassName('cell')[index].textContent = currentPlayer;
        checkWin();
        togglePlayer();
    }
}

function togglePlayer() {
    currentPlayer = currentPlayer === 'X' ? 'O' : 'X';
}

function checkWin() {
    var winningCombinations = [
        [0, 1, 2],
        [3, 4, 5],
        [6, 7, 8],
        [0, 3, 6],
        [1, 4, 7],
        [2, 5, 8],
        [0, 4, 8],
        [2, 4, 6]
    ];

    for (var i = 0; i < winningCombinations.length; i++) {
        var [a, b, c] = winningCombinations[i];
        if (board[a] !== '' && board[a] === board[b] && board[a] === board[c]) {
            endGame(board[a]);
            break;
        }
    }

    if (!board.includes('') && !gameEnded) {
        endGame('draw');
    }
}

function endGame(winner) {
    gameEnded = true;
    var message = winner === 'draw' ? "It's a draw!" : "Player " + winner + " wins!";
    alert(message);
}

function resetBoard() {
    currentPlayer = 'X';
    gameEnded = false;
    board = ['', '', '', '', '', '', '', '', ''];
    var cells = document.getElementsByClassName('cell');
    for (var i = 0; i < cells.length; i++) {
        cells[i].textContent = '';
    }
}
