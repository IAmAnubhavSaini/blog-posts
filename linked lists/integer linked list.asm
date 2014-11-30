; Listing generated by Microsoft (R) Optimizing Compiler Version 18.00.30723.0 

include listing.inc

INCLUDELIB LIBCMT
INCLUDELIB OLDNAMES

_DATA	SEGMENT
$SG4467	DB	0aH, 'debug: entering create_list.', 00H
	ORG $+2
$SG4474	DB	0aH, 'debug: exiting create_list.', 00H
	ORG $+3
$SG4484	DB	0aH, 'debug: entering add_to_list.', 00H
	ORG $+2
$SG4492	DB	0aH, 'debug: entering add_to_list.', 00H
	ORG $+2
$SG4496	DB	0aH, 'debug: entering make_list_circular.', 00H
	ORG $+3
$SG4501	DB	0aH, 'debug: exiting make_list_circular.', 00H
	ORG $+4
$SG4505	DB	0aH, 'debug: entering print_list.', 00H
	ORG $+3
$SG4508	DB	0aH, 'Circular list.', 00H
$SG4512	DB	0aH, 'The values of the list are : ', 00H
	ORG $+1
$SG4516	DB	' [%d]-> ', 00H
	ORG $+7
$SG4517	DB	'[NULL]', 0aH, 00H
$SG4519	DB	0aH, 'Empty list.', 00H
	ORG $+3
$SG4520	DB	0aH, 'debug: exiting print_list.', 00H
	ORG $+4
$SG4544	DB	0aH, 'debug: at least two nodes exists.', 00H
	ORG $+5
$SG4551	DB	0aH, 'debug: only one node exists.', 00H
_DATA	ENDS
PUBLIC	create_list
PUBLIC	add_to_list
PUBLIC	make_list_circular
PUBLIC	print_list
PUBLIC	search_list
PUBLIC	delete_first_value_matching_node
PUBLIC	delete_all_value_matching_nodes
PUBLIC	is_list_empty
PUBLIC	is_list_circular
EXTRN	printf:PROC
EXTRN	abort:PROC
EXTRN	malloc:PROC
pdata	SEGMENT
$pdata$create_list DD imagerel $LN4
	DD	imagerel $LN4+96
	DD	imagerel $unwind$create_list
$pdata$add_to_list DD imagerel $LN6
	DD	imagerel $LN6+204
	DD	imagerel $unwind$add_to_list
$pdata$make_list_circular DD imagerel $LN5
	DD	imagerel $LN5+98
	DD	imagerel $unwind$make_list_circular
$pdata$print_list DD imagerel $LN9
	DD	imagerel $LN9+173
	DD	imagerel $unwind$print_list
$pdata$search_list DD imagerel $LN6
	DD	imagerel $LN6+79
	DD	imagerel $unwind$search_list
$pdata$delete_first_value_matching_node DD imagerel $LN9
	DD	imagerel $LN9+205
	DD	imagerel $unwind$delete_first_value_matching_node
$pdata$delete_all_value_matching_nodes DD imagerel $LN9
	DD	imagerel $LN9+168
	DD	imagerel $unwind$delete_all_value_matching_nodes
$pdata$is_list_circular DD imagerel $LN6
	DD	imagerel $LN6+119
	DD	imagerel $unwind$is_list_circular
pdata	ENDS
xdata	SEGMENT
$unwind$create_list DD 010801H
	DD	06208H
$unwind$add_to_list DD 011801H
	DD	06218H
$unwind$make_list_circular DD 010901H
	DD	06209H
$unwind$print_list DD 010901H
	DD	06209H
$unwind$search_list DD 010d01H
	DD	0220dH
$unwind$delete_first_value_matching_node DD 010d01H
	DD	0820dH
$unwind$delete_all_value_matching_nodes DD 010d01H
	DD	0420dH
$unwind$is_list_circular DD 010901H
	DD	02209H
xdata	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
fast$ = 0
slow$ = 8
head$ = 32
is_list_circular PROC
; File c:\src\blog posts\linked lists\integer linked list.c
; Line 158
$LN6:
	mov	QWORD PTR [rsp+8], rcx
	sub	rsp, 24
; Line 159
	mov	rax, QWORD PTR head$[rsp]
	mov	QWORD PTR slow$[rsp], rax
; Line 160
	mov	rax, QWORD PTR head$[rsp]
	mov	QWORD PTR fast$[rsp], rax
$LN3@is_list_ci:
; Line 161
	cmp	QWORD PTR slow$[rsp], 0
	je	SHORT $LN2@is_list_ci
	cmp	QWORD PTR fast$[rsp], 0
	je	SHORT $LN2@is_list_ci
	mov	rax, QWORD PTR fast$[rsp]
	cmp	QWORD PTR [rax+8], 0
	je	SHORT $LN2@is_list_ci
	mov	rax, QWORD PTR fast$[rsp]
	cmp	QWORD PTR [rax+8], 0
	je	SHORT $LN2@is_list_ci
; Line 162
	mov	rax, QWORD PTR fast$[rsp]
	mov	rax, QWORD PTR [rax+8]
	mov	rax, QWORD PTR [rax+8]
	mov	QWORD PTR fast$[rsp], rax
; Line 163
	mov	rax, QWORD PTR slow$[rsp]
	mov	rax, QWORD PTR [rax+8]
	mov	QWORD PTR slow$[rsp], rax
; Line 164
	mov	rax, QWORD PTR fast$[rsp]
	cmp	QWORD PTR slow$[rsp], rax
	jne	SHORT $LN1@is_list_ci
; Line 165
	mov	al, 1
	jmp	SHORT $LN4@is_list_ci
$LN1@is_list_ci:
; Line 167
	jmp	SHORT $LN3@is_list_ci
$LN2@is_list_ci:
; Line 168
	xor	al, al
$LN4@is_list_ci:
; Line 169
	add	rsp, 24
	ret	0
is_list_circular ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
head$ = 8
is_list_empty PROC
; File c:\src\blog posts\linked lists\integer linked list.c
; Line 171
	mov	QWORD PTR [rsp+8], rcx
; Line 172
	cmp	QWORD PTR head$[rsp], 0
	jne	SHORT $LN2@is_list_em
; Line 173
	mov	al, 1
	jmp	SHORT $LN3@is_list_em
; Line 174
	jmp	SHORT $LN1@is_list_em
$LN2@is_list_em:
; Line 175
	xor	al, al
$LN1@is_list_em:
$LN3@is_list_em:
; Line 176
	ret	0
is_list_empty ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
isDeleted$ = 0
curr$ = 8
prev$ = 16
head$ = 48
val$ = 56
delete_all_value_matching_nodes PROC
; File c:\src\blog posts\linked lists\integer linked list.c
; Line 133
$LN9:
	mov	DWORD PTR [rsp+16], edx
	mov	QWORD PTR [rsp+8], rcx
	sub	rsp, 40					; 00000028H
; Line 134
	mov	rax, QWORD PTR head$[rsp]
	mov	QWORD PTR prev$[rsp], rax
; Line 135
	mov	QWORD PTR curr$[rsp], 0
; Line 136
	mov	BYTE PTR isDeleted$[rsp], 0
; Line 137
	mov	rax, QWORD PTR head$[rsp]
	cmp	QWORD PTR [rax+8], 0
	je	SHORT $LN6@delete_all
; Line 138
	mov	rax, QWORD PTR head$[rsp]
	mov	rax, QWORD PTR [rax+8]
	mov	QWORD PTR curr$[rsp], rax
$LN5@delete_all:
; Line 139
	cmp	QWORD PTR curr$[rsp], 0
	je	SHORT $LN4@delete_all
; Line 140
	mov	rax, QWORD PTR curr$[rsp]
	mov	ecx, DWORD PTR val$[rsp]
	cmp	DWORD PTR [rax], ecx
	jne	SHORT $LN3@delete_all
; Line 141
	mov	BYTE PTR isDeleted$[rsp], 1
; Line 142
	mov	rax, QWORD PTR prev$[rsp]
	mov	rcx, QWORD PTR curr$[rsp]
	mov	rcx, QWORD PTR [rcx+8]
	mov	QWORD PTR [rax+8], rcx
$LN3@delete_all:
; Line 145
	mov	rax, QWORD PTR curr$[rsp]
	mov	QWORD PTR prev$[rsp], rax
; Line 146
	mov	rax, QWORD PTR curr$[rsp]
	mov	rax, QWORD PTR [rax+8]
	mov	QWORD PTR curr$[rsp], rax
; Line 147
	jmp	SHORT $LN5@delete_all
$LN4@delete_all:
; Line 149
	jmp	SHORT $LN2@delete_all
$LN6@delete_all:
; Line 150
	mov	rax, QWORD PTR prev$[rsp]
	mov	ecx, DWORD PTR val$[rsp]
	cmp	DWORD PTR [rax], ecx
	jne	SHORT $LN1@delete_all
; Line 151
	mov	BYTE PTR isDeleted$[rsp], 1
; Line 152
	mov	QWORD PTR prev$[rsp], 0
$LN1@delete_all:
$LN2@delete_all:
; Line 155
	movzx	eax, BYTE PTR isDeleted$[rsp]
; Line 156
	add	rsp, 40					; 00000028H
	ret	0
delete_all_value_matching_nodes ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
isDeleted$ = 32
curr$ = 40
prev$ = 48
head$ = 80
val$ = 88
delete_first_value_matching_node PROC
; File c:\src\blog posts\linked lists\integer linked list.c
; Line 101
$LN9:
	mov	DWORD PTR [rsp+16], edx
	mov	QWORD PTR [rsp+8], rcx
	sub	rsp, 72					; 00000048H
; Line 102
	mov	rax, QWORD PTR head$[rsp]
	mov	QWORD PTR prev$[rsp], rax
; Line 103
	mov	QWORD PTR curr$[rsp], 0
; Line 104
	mov	BYTE PTR isDeleted$[rsp], 0
; Line 105
	mov	rax, QWORD PTR head$[rsp]
	cmp	QWORD PTR [rax+8], 0
	je	SHORT $LN6@delete_fir
; Line 106
	mov	rax, QWORD PTR head$[rsp]
	mov	rax, QWORD PTR [rax+8]
	mov	QWORD PTR curr$[rsp], rax
; Line 108
	lea	rcx, OFFSET FLAT:$SG4544
	call	printf
$LN5@delete_fir:
; Line 110
	cmp	QWORD PTR curr$[rsp], 0
	je	SHORT $LN4@delete_fir
	movzx	eax, BYTE PTR isDeleted$[rsp]
	test	eax, eax
	jne	SHORT $LN4@delete_fir
; Line 111
	mov	rax, QWORD PTR curr$[rsp]
	mov	ecx, DWORD PTR val$[rsp]
	cmp	DWORD PTR [rax], ecx
	jne	SHORT $LN3@delete_fir
; Line 112
	mov	rax, QWORD PTR prev$[rsp]
	mov	rcx, QWORD PTR curr$[rsp]
	mov	rcx, QWORD PTR [rcx+8]
	mov	QWORD PTR [rax+8], rcx
; Line 113
	mov	BYTE PTR isDeleted$[rsp], 1
$LN3@delete_fir:
; Line 116
	mov	rax, QWORD PTR curr$[rsp]
	mov	QWORD PTR prev$[rsp], rax
; Line 117
	mov	rax, QWORD PTR curr$[rsp]
	mov	rax, QWORD PTR [rax+8]
	mov	QWORD PTR curr$[rsp], rax
; Line 118
	jmp	SHORT $LN5@delete_fir
$LN4@delete_fir:
; Line 120
	jmp	SHORT $LN2@delete_fir
$LN6@delete_fir:
; Line 122
	lea	rcx, OFFSET FLAT:$SG4551
	call	printf
; Line 124
	mov	rax, QWORD PTR prev$[rsp]
	mov	ecx, DWORD PTR val$[rsp]
	cmp	DWORD PTR [rax], ecx
	jne	SHORT $LN1@delete_fir
; Line 125
	mov	BYTE PTR isDeleted$[rsp], 1
; Line 127
	mov	QWORD PTR prev$[rsp], 0
$LN1@delete_fir:
$LN2@delete_fir:
; Line 130
	movzx	eax, BYTE PTR isDeleted$[rsp]
; Line 131
	add	rsp, 72					; 00000048H
	ret	0
delete_first_value_matching_node ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
isFound$ = 0
start$ = 8
head$ = 32
val$ = 40
search_list PROC
; File c:\src\blog posts\linked lists\integer linked list.c
; Line 88
$LN6:
	mov	DWORD PTR [rsp+16], edx
	mov	QWORD PTR [rsp+8], rcx
	sub	rsp, 24
; Line 89
	mov	rax, QWORD PTR head$[rsp]
	mov	QWORD PTR start$[rsp], rax
; Line 90
	mov	BYTE PTR isFound$[rsp], 0
$LN3@search_lis:
; Line 91
	cmp	QWORD PTR start$[rsp], 0
	je	SHORT $LN2@search_lis
; Line 92
	mov	rax, QWORD PTR start$[rsp]
	mov	ecx, DWORD PTR val$[rsp]
	cmp	DWORD PTR [rax], ecx
	jne	SHORT $LN1@search_lis
; Line 93
	mov	BYTE PTR isFound$[rsp], 1
; Line 94
	jmp	SHORT $LN2@search_lis
$LN1@search_lis:
; Line 96
	mov	rax, QWORD PTR start$[rsp]
	mov	rax, QWORD PTR [rax+8]
	mov	QWORD PTR start$[rsp], rax
; Line 97
	jmp	SHORT $LN3@search_lis
$LN2@search_lis:
; Line 98
	movzx	eax, BYTE PTR isFound$[rsp]
; Line 99
	add	rsp, 24
	ret	0
search_list ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
ptr$ = 32
head$ = 64
print_list PROC
; File c:\src\blog posts\linked lists\integer linked list.c
; Line 62
$LN9:
	mov	QWORD PTR [rsp+8], rcx
	sub	rsp, 56					; 00000038H
; Line 64
	lea	rcx, OFFSET FLAT:$SG4505
	call	printf
; Line 66
	mov	rax, QWORD PTR head$[rsp]
	mov	QWORD PTR ptr$[rsp], rax
; Line 67
	mov	rcx, QWORD PTR head$[rsp]
	call	is_list_circular
	movzx	eax, al
	test	eax, eax
	je	SHORT $LN6@print_list
; Line 68
	lea	rcx, OFFSET FLAT:$SG4508
	call	printf
; Line 70
	jmp	SHORT $LN5@print_list
$LN6@print_list:
; Line 71
	cmp	QWORD PTR ptr$[rsp], 0
	je	SHORT $LN4@print_list
; Line 72
	lea	rcx, OFFSET FLAT:$SG4512
	call	printf
$LN3@print_list:
; Line 73
	cmp	QWORD PTR ptr$[rsp], 0
	je	SHORT $LN2@print_list
; Line 74
	mov	r8, QWORD PTR ptr$[rsp]
	mov	rax, QWORD PTR ptr$[rsp]
	mov	edx, DWORD PTR [rax]
	lea	rcx, OFFSET FLAT:$SG4516
	call	printf
; Line 75
	mov	rax, QWORD PTR ptr$[rsp]
	mov	rax, QWORD PTR [rax+8]
	mov	QWORD PTR ptr$[rsp], rax
; Line 76
	jmp	SHORT $LN3@print_list
$LN2@print_list:
; Line 77
	lea	rcx, OFFSET FLAT:$SG4517
	call	printf
; Line 79
	jmp	SHORT $LN1@print_list
$LN4@print_list:
; Line 80
	lea	rcx, OFFSET FLAT:$SG4519
	call	printf
$LN1@print_list:
$LN5@print_list:
; Line 84
	lea	rcx, OFFSET FLAT:$SG4520
	call	printf
; Line 86
	add	rsp, 56					; 00000038H
	ret	0
print_list ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
tmp$ = 32
head$ = 64
make_list_circular PROC
; File c:\src\blog posts\linked lists\integer linked list.c
; Line 48
$LN5:
	mov	QWORD PTR [rsp+8], rcx
	sub	rsp, 56					; 00000038H
; Line 50
	lea	rcx, OFFSET FLAT:$SG4496
	call	printf
; Line 52
	mov	rax, QWORD PTR head$[rsp]
	mov	QWORD PTR tmp$[rsp], rax
$LN2@make_list_:
; Line 53
	cmp	QWORD PTR tmp$[rsp], 0
	je	SHORT $LN1@make_list_
	mov	rax, QWORD PTR tmp$[rsp]
	cmp	QWORD PTR [rax+8], 0
	je	SHORT $LN1@make_list_
; Line 54
	mov	rax, QWORD PTR tmp$[rsp]
	mov	rax, QWORD PTR [rax+8]
	mov	QWORD PTR tmp$[rsp], rax
; Line 55
	jmp	SHORT $LN2@make_list_
$LN1@make_list_:
; Line 56
	mov	rax, QWORD PTR tmp$[rsp]
	mov	rcx, QWORD PTR head$[rsp]
	mov	QWORD PTR [rax+8], rcx
; Line 58
	lea	rcx, OFFSET FLAT:$SG4501
	call	printf
; Line 60
	add	rsp, 56					; 00000038H
	ret	0
make_list_circular ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
newTS$ = 32
head$ = 64
curr$ = 72
val$ = 80
before_head$ = 88
add_to_list PROC
; File c:\src\blog posts\linked lists\integer linked list.c
; Line 21
$LN6:
	mov	BYTE PTR [rsp+32], r9b
	mov	DWORD PTR [rsp+24], r8d
	mov	QWORD PTR [rsp+16], rdx
	mov	QWORD PTR [rsp+8], rcx
	sub	rsp, 56					; 00000038H
; Line 23
	lea	rcx, OFFSET FLAT:$SG4484
	call	printf
; Line 25
	mov	ecx, 16
	call	malloc
	mov	QWORD PTR newTS$[rsp], rax
; Line 26
	mov	rcx, QWORD PTR head$[rsp]
	call	is_list_empty
	movzx	eax, al
	test	eax, eax
	je	SHORT $LN3@add_to_lis
; Line 27
	mov	ecx, DWORD PTR val$[rsp]
	call	create_list
	jmp	SHORT $LN4@add_to_lis
$LN3@add_to_lis:
; Line 30
	movzx	eax, BYTE PTR before_head$[rsp]
	test	eax, eax
	je	SHORT $LN2@add_to_lis
; Line 31
	mov	rax, QWORD PTR newTS$[rsp]
	mov	ecx, DWORD PTR val$[rsp]
	mov	DWORD PTR [rax], ecx
; Line 32
	mov	rax, QWORD PTR newTS$[rsp]
	mov	rcx, QWORD PTR head$[rsp]
	mov	QWORD PTR [rax+8], rcx
; Line 33
	mov	rax, QWORD PTR newTS$[rsp]
	mov	QWORD PTR head$[rsp], rax
; Line 34
	mov	rax, QWORD PTR head$[rsp]
	jmp	SHORT $LN4@add_to_lis
; Line 36
	jmp	SHORT $LN1@add_to_lis
$LN2@add_to_lis:
; Line 37
	mov	rax, QWORD PTR newTS$[rsp]
	mov	ecx, DWORD PTR val$[rsp]
	mov	DWORD PTR [rax], ecx
; Line 38
	mov	rax, QWORD PTR newTS$[rsp]
	mov	QWORD PTR [rax+8], 0
; Line 39
	mov	rax, QWORD PTR curr$[rsp]
	mov	rcx, QWORD PTR newTS$[rsp]
	mov	QWORD PTR [rax+8], rcx
; Line 40
	mov	rax, QWORD PTR newTS$[rsp]
	mov	QWORD PTR curr$[rsp], rax
; Line 41
	mov	rax, QWORD PTR curr$[rsp]
	jmp	SHORT $LN4@add_to_lis
$LN1@add_to_lis:
; Line 44
	lea	rcx, OFFSET FLAT:$SG4492
	call	printf
$LN4@add_to_lis:
; Line 46
	add	rsp, 56					; 00000038H
	ret	0
add_to_list ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
ptr$ = 32
val$ = 64
create_list PROC
; File c:\src\blog posts\linked lists\integer linked list.c
; Line 4
$LN4:
	mov	DWORD PTR [rsp+8], ecx
	sub	rsp, 56					; 00000038H
; Line 6
	lea	rcx, OFFSET FLAT:$SG4467
	call	printf
; Line 8
	mov	ecx, 16
	call	malloc
	mov	QWORD PTR ptr$[rsp], rax
; Line 9
	cmp	QWORD PTR ptr$[rsp], 0
	jne	SHORT $LN1@create_lis
; Line 10
	call	abort
$LN1@create_lis:
; Line 12
	mov	rax, QWORD PTR ptr$[rsp]
	mov	ecx, DWORD PTR val$[rsp]
	mov	DWORD PTR [rax], ecx
; Line 13
	mov	rax, QWORD PTR ptr$[rsp]
	mov	QWORD PTR [rax+8], 0
; Line 15
	mov	rax, QWORD PTR ptr$[rsp]
	jmp	SHORT $LN2@create_lis
; Line 17
	lea	rcx, OFFSET FLAT:$SG4474
	call	printf
$LN2@create_lis:
$LN3@create_lis:
; Line 19
	add	rsp, 56					; 00000038H
	ret	0
create_list ENDP
_TEXT	ENDS
END
