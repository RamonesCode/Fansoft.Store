let _id = 0;
let _tipo = '';
let _url = '';

const myModal = new bootstrap.Modal(document.getElementById('excluirModal'), {
    keyboard: false
});

function excluir(id, nome, tipo, url) {
    const body = `${tipo} ${nome}`;
    document.querySelector("#modalBody-desc").textContent = body;
    _id = id;
    _tipo = tipo;
    _url = url + "/";
    myModal.show();
}

function confirmeDel() {
    // XMLHttpRequest();

    fetch(_url + _id, { method: 'delete' })
        .then((response) => {
            myModal.hide();
            console.log(response);
            let mensagem = { error : false, msg : ''};
            switch (response.status) {
                case 204:
                    mensagem.error = false;
                    mensagem.msg = _tipo + ' excluído';
                    break;
                case 400:
                    mensagem.error = true;
                    mensagem.msg = _tipo + ' não existe';
                    break;
                default:
                    mensagem.error = true;
                    mensagem.msg = 'Erro ao tentar excluir';
            }

            if (mensagem.error) {
                toastr.error(mensagem.msg, "Fansoft Store");
            } else {
                toastr.success(mensagem.msg, "Fansoft Store");
                document.getElementById('item-' + _id).remove();
            }

        });
}