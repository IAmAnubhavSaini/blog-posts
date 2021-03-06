; Listing generated by Microsoft (R) Optimizing Compiler Version 17.00.60610.1 

	TITLE	d:\source\blog posts\linked lists\linked list.c
	.686P
	.XMM
	include listing.inc
	.model	flat

INCLUDELIB LIBCMT
INCLUDELIB OLDNAMES

_DATA	SEGMENT
$SG4292	DB	0aH, 'debug: entering create_node with value : %d.', 00H
	ORG $+2
$SG4298	DB	0aH, 'debug: exiting create_node.', 00H
	ORG $+3
$SG4308	DB	0aH, 'debug: entering add_to_list with value.', 00H
	ORG $+3
$SG4313	DB	0aH, 'debug: exiting add_to_list.', 00H
	ORG $+3
$SG4318	DB	0aH, 'debug: entering make_list_circular.', 00H
	ORG $+3
$SG4322	DB	0aH, 'debug: exiting make_list_circular.', 00H
$SG4346	DB	0aH, 'debug: entering print_list.', 00H
	ORG $+3
$SG4348	DB	0aH, 'Circular list; not printing.', 00H
	ORG $+2
$SG4351	DB	0aH, 'The values of the list are : ', 00H
	ORG $+1
$SG4357	DB	' [%d]-> ', 00H
	ORG $+3
$SG4361	DB	' [%s]-> ', 00H
	ORG $+3
$SG4363	DB	' [cannot print @ %p]-> ', 00H
$SG4364	DB	'[NULL]', 0aH, 00H
$SG4366	DB	0aH, 'Empty list.', 00H
	ORG $+3
$SG4367	DB	0aH, 'debug: exiting print_list.', 00H
$SG4392	DB	0aH, 'debug: at least two nodes exists.', 00H
	ORG $+1
$SG4400	DB	0aH, 'debug: only one node exists.', 00H
_DATA	ENDS
PUBLIC	_create_node
PUBLIC	_add_to_list
PUBLIC	_insert_in_list
PUBLIC	_tail_insert_in_list
PUBLIC	_mid_insert_in_list
PUBLIC	_head_insert_in_list
PUBLIC	_insert_in_list_after
PUBLIC	_make_list_circular
PUBLIC	_make_list_acircular
PUBLIC	_print_list
PUBLIC	_search_list_for_integer
PUBLIC	_delete_first_integer_value_matching_node
PUBLIC	_delete_all_integer_value_matching_nodes
PUBLIC	_is_list_empty
PUBLIC	_is_list_circular
PUBLIC	_create_stack_from_existing_list
EXTRN	_printf:PROC
EXTRN	_abort:PROC
EXTRN	_malloc:PROC
; Function compile flags: /Odtp
_TEXT	SEGMENT
_otherListHead$ = 8					; size = 4
_otherListUpto$ = 12					; size = 4
_create_stack_from_existing_list PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 213
	push	ebp
	mov	ebp, esp
; Line 215
	xor	eax, eax
; Line 216
	pop	ebp
	ret	0
_create_stack_from_existing_list ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_slow$ = -8						; size = 4
_fast$ = -4						; size = 4
_head$ = 8						; size = 4
_is_list_circular PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 190
	push	ebp
	mov	ebp, esp
	sub	esp, 8
; Line 191
	mov	eax, DWORD PTR _head$[ebp]
	mov	DWORD PTR _slow$[ebp], eax
; Line 192
	mov	ecx, DWORD PTR _head$[ebp]
	mov	DWORD PTR _fast$[ebp], ecx
; Line 193
	cmp	DWORD PTR _head$[ebp], 0
	je	SHORT $LN3@is_list_ci
	mov	edx, DWORD PTR _head$[ebp]
	cmp	DWORD PTR [edx+4], 0
	jne	SHORT $LN3@is_list_ci
; Line 194
	xor	eax, eax
	jmp	SHORT $LN5@is_list_ci
$LN3@is_list_ci:
; Line 196
	cmp	DWORD PTR _slow$[ebp], 0
	je	SHORT $LN2@is_list_ci
	cmp	DWORD PTR _fast$[ebp], 0
	je	SHORT $LN2@is_list_ci
	mov	eax, DWORD PTR _fast$[ebp]
	cmp	DWORD PTR [eax+4], 0
	je	SHORT $LN2@is_list_ci
; Line 197
	mov	ecx, DWORD PTR _fast$[ebp]
	mov	edx, DWORD PTR [ecx+4]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR _fast$[ebp], eax
; Line 198
	mov	ecx, DWORD PTR _slow$[ebp]
	mov	edx, DWORD PTR [ecx+4]
	mov	DWORD PTR _slow$[ebp], edx
; Line 199
	mov	eax, DWORD PTR _slow$[ebp]
	cmp	eax, DWORD PTR _fast$[ebp]
	jne	SHORT $LN1@is_list_ci
; Line 200
	mov	eax, 1
	jmp	SHORT $LN5@is_list_ci
$LN1@is_list_ci:
; Line 202
	jmp	SHORT $LN3@is_list_ci
$LN2@is_list_ci:
; Line 203
	xor	eax, eax
$LN5@is_list_ci:
; Line 204
	mov	esp, ebp
	pop	ebp
	ret	0
_is_list_circular ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_head$ = 8						; size = 4
_is_list_empty PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 206
	push	ebp
	mov	ebp, esp
; Line 207
	cmp	DWORD PTR _head$[ebp], 0
	jne	SHORT $LN2@is_list_em
; Line 208
	mov	eax, 1
	jmp	SHORT $LN3@is_list_em
; Line 209
	jmp	SHORT $LN3@is_list_em
$LN2@is_list_em:
; Line 210
	xor	eax, eax
$LN3@is_list_em:
; Line 211
	pop	ebp
	ret	0
_is_list_empty ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_isDeleted$ = -12					; size = 4
_prev$ = -8						; size = 4
_curr$ = -4						; size = 4
_head$ = 8						; size = 4
_val$ = 12						; size = 4
_delete_all_integer_value_matching_nodes PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 165
	push	ebp
	mov	ebp, esp
	sub	esp, 12					; 0000000cH
; Line 166
	mov	eax, DWORD PTR _head$[ebp]
	mov	DWORD PTR _prev$[ebp], eax
; Line 167
	mov	DWORD PTR _curr$[ebp], 0
; Line 168
	mov	DWORD PTR _isDeleted$[ebp], 0
; Line 169
	mov	ecx, DWORD PTR _head$[ebp]
	cmp	DWORD PTR [ecx+4], 0
	je	SHORT $LN6@delete_all
; Line 170
	mov	edx, DWORD PTR _head$[ebp]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR _curr$[ebp], eax
$LN5@delete_all:
; Line 171
	cmp	DWORD PTR _curr$[ebp], 0
	je	SHORT $LN4@delete_all
; Line 172
	mov	ecx, DWORD PTR _curr$[ebp]
	mov	edx, DWORD PTR [ecx]
	mov	eax, DWORD PTR [edx]
	cmp	eax, DWORD PTR _val$[ebp]
	jne	SHORT $LN3@delete_all
; Line 173
	mov	DWORD PTR _isDeleted$[ebp], 1
; Line 174
	mov	ecx, DWORD PTR _prev$[ebp]
	mov	edx, DWORD PTR _curr$[ebp]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR [ecx+4], eax
$LN3@delete_all:
; Line 177
	mov	ecx, DWORD PTR _curr$[ebp]
	mov	DWORD PTR _prev$[ebp], ecx
; Line 178
	mov	edx, DWORD PTR _curr$[ebp]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR _curr$[ebp], eax
; Line 179
	jmp	SHORT $LN5@delete_all
$LN4@delete_all:
; Line 181
	jmp	SHORT $LN2@delete_all
$LN6@delete_all:
; Line 182
	mov	ecx, DWORD PTR _prev$[ebp]
	mov	edx, DWORD PTR [ecx]
	mov	eax, DWORD PTR [edx]
	cmp	eax, DWORD PTR _val$[ebp]
	jne	SHORT $LN2@delete_all
; Line 183
	mov	DWORD PTR _isDeleted$[ebp], 1
; Line 184
	mov	DWORD PTR _prev$[ebp], 0
$LN2@delete_all:
; Line 187
	mov	eax, DWORD PTR _isDeleted$[ebp]
; Line 188
	mov	esp, ebp
	pop	ebp
	ret	0
_delete_all_integer_value_matching_nodes ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_isDeleted$ = -12					; size = 4
_prev$ = -8						; size = 4
_curr$ = -4						; size = 4
_head$ = 8						; size = 4
_val$ = 12						; size = 4
_delete_first_integer_value_matching_node PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 133
	push	ebp
	mov	ebp, esp
	sub	esp, 12					; 0000000cH
; Line 134
	mov	eax, DWORD PTR _head$[ebp]
	mov	DWORD PTR _prev$[ebp], eax
; Line 135
	mov	DWORD PTR _curr$[ebp], 0
; Line 136
	mov	DWORD PTR _isDeleted$[ebp], 0
; Line 137
	mov	ecx, DWORD PTR _head$[ebp]
	cmp	DWORD PTR [ecx+4], 0
	je	SHORT $LN6@delete_fir
; Line 138
	mov	edx, DWORD PTR _head$[ebp]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR _curr$[ebp], eax
; Line 140
	push	OFFSET $SG4392
	call	_printf
	add	esp, 4
$LN5@delete_fir:
; Line 142
	cmp	DWORD PTR _curr$[ebp], 0
	je	SHORT $LN4@delete_fir
	cmp	DWORD PTR _isDeleted$[ebp], 0
	jne	SHORT $LN4@delete_fir
; Line 143
	mov	ecx, DWORD PTR _curr$[ebp]
	mov	edx, DWORD PTR [ecx]
	mov	eax, DWORD PTR [edx]
	cmp	eax, DWORD PTR _val$[ebp]
	jne	SHORT $LN3@delete_fir
; Line 144
	mov	ecx, DWORD PTR _prev$[ebp]
	mov	edx, DWORD PTR _curr$[ebp]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR [ecx+4], eax
; Line 145
	mov	DWORD PTR _isDeleted$[ebp], 1
$LN3@delete_fir:
; Line 148
	mov	ecx, DWORD PTR _curr$[ebp]
	mov	DWORD PTR _prev$[ebp], ecx
; Line 149
	mov	edx, DWORD PTR _curr$[ebp]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR _curr$[ebp], eax
; Line 150
	jmp	SHORT $LN5@delete_fir
$LN4@delete_fir:
; Line 152
	jmp	SHORT $LN2@delete_fir
$LN6@delete_fir:
; Line 154
	push	OFFSET $SG4400
	call	_printf
	add	esp, 4
; Line 156
	mov	ecx, DWORD PTR _prev$[ebp]
	mov	edx, DWORD PTR [ecx]
	mov	eax, DWORD PTR [edx]
	cmp	eax, DWORD PTR _val$[ebp]
	jne	SHORT $LN2@delete_fir
; Line 157
	mov	DWORD PTR _isDeleted$[ebp], 1
; Line 159
	mov	DWORD PTR _prev$[ebp], 0
$LN2@delete_fir:
; Line 162
	mov	eax, DWORD PTR _isDeleted$[ebp]
; Line 163
	mov	esp, ebp
	pop	ebp
	ret	0
_delete_first_integer_value_matching_node ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_isFound$ = -8						; size = 4
_start$ = -4						; size = 4
_head$ = 8						; size = 4
_val$ = 12						; size = 4
_search_list_for_integer PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 120
	push	ebp
	mov	ebp, esp
	sub	esp, 8
; Line 121
	mov	eax, DWORD PTR _head$[ebp]
	mov	DWORD PTR _start$[ebp], eax
; Line 122
	mov	DWORD PTR _isFound$[ebp], 0
$LN3@search_lis:
; Line 123
	cmp	DWORD PTR _start$[ebp], 0
	je	SHORT $LN2@search_lis
; Line 124
	mov	ecx, DWORD PTR _start$[ebp]
	mov	edx, DWORD PTR [ecx]
	mov	eax, DWORD PTR [edx]
	cmp	eax, DWORD PTR _val$[ebp]
	jne	SHORT $LN1@search_lis
; Line 125
	mov	DWORD PTR _isFound$[ebp], 1
; Line 126
	jmp	SHORT $LN2@search_lis
$LN1@search_lis:
; Line 128
	mov	ecx, DWORD PTR _start$[ebp]
	mov	edx, DWORD PTR [ecx+4]
	mov	DWORD PTR _start$[ebp], edx
; Line 129
	jmp	SHORT $LN3@search_lis
$LN2@search_lis:
; Line 130
	mov	eax, DWORD PTR _isFound$[ebp]
; Line 131
	mov	esp, ebp
	pop	ebp
	ret	0
_search_list_for_integer ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_ptr$ = -4						; size = 4
_head$ = 8						; size = 4
_print_list PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 85
	push	ebp
	mov	ebp, esp
	push	ecx
; Line 88
	push	OFFSET $SG4346
	call	_printf
	add	esp, 4
; Line 90
	mov	eax, DWORD PTR _head$[ebp]
	mov	DWORD PTR _ptr$[ebp], eax
; Line 91
	mov	ecx, DWORD PTR _head$[ebp]
	push	ecx
	call	_is_list_circular
	add	esp, 4
	test	eax, eax
	je	SHORT $LN10@print_list
; Line 92
	push	OFFSET $SG4348
	call	_printf
	add	esp, 4
; Line 94
	jmp	$LN9@print_list
$LN10@print_list:
; Line 95
	cmp	DWORD PTR _ptr$[ebp], 0
	je	SHORT $LN8@print_list
; Line 96
	push	OFFSET $SG4351
	call	_printf
	add	esp, 4
$LN7@print_list:
; Line 97
	cmp	DWORD PTR _ptr$[ebp], 0
	je	SHORT $LN6@print_list
; Line 98
	mov	edx, DWORD PTR _ptr$[ebp]
	cmp	DWORD PTR [edx+8], 1
	jne	SHORT $LN5@print_list
; Line 99
	mov	eax, DWORD PTR _ptr$[ebp]
	mov	ecx, DWORD PTR [eax]
	mov	edx, DWORD PTR [ecx]
	push	edx
	push	OFFSET $SG4357
	call	_printf
	add	esp, 8
	jmp	SHORT $LN4@print_list
$LN5@print_list:
; Line 101
	mov	eax, DWORD PTR _ptr$[ebp]
	cmp	DWORD PTR [eax+8], 2
	jne	SHORT $LN3@print_list
; Line 102
	mov	ecx, DWORD PTR _ptr$[ebp]
	mov	edx, DWORD PTR [ecx]
	push	edx
	push	OFFSET $SG4361
	call	_printf
	add	esp, 8
; Line 104
	jmp	SHORT $LN4@print_list
$LN3@print_list:
; Line 105
	mov	eax, DWORD PTR _ptr$[ebp]
	push	eax
	push	OFFSET $SG4363
	call	_printf
	add	esp, 8
$LN4@print_list:
; Line 107
	mov	ecx, DWORD PTR _ptr$[ebp]
	mov	edx, DWORD PTR [ecx+4]
	mov	DWORD PTR _ptr$[ebp], edx
; Line 108
	jmp	SHORT $LN7@print_list
$LN6@print_list:
; Line 109
	push	OFFSET $SG4364
	call	_printf
	add	esp, 4
; Line 111
	jmp	SHORT $LN9@print_list
$LN8@print_list:
; Line 112
	push	OFFSET $SG4366
	call	_printf
	add	esp, 4
$LN9@print_list:
; Line 116
	push	OFFSET $SG4367
	call	_printf
	add	esp, 4
; Line 118
	mov	esp, ebp
	pop	ebp
	ret	0
_print_list ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_slow$ = -8						; size = 4
_fast$ = -4						; size = 4
_head$ = 8						; size = 4
_make_list_acircular PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 57
	push	ebp
	mov	ebp, esp
	sub	esp, 8
; Line 60
	mov	eax, DWORD PTR _head$[ebp]
	mov	DWORD PTR _fast$[ebp], eax
	mov	ecx, DWORD PTR _fast$[ebp]
	mov	DWORD PTR _slow$[ebp], ecx
; Line 61
	cmp	DWORD PTR _head$[ebp], 0
	jne	SHORT $LN9@make_list_
; Line 62
	jmp	$LN10@make_list_
$LN9@make_list_:
; Line 64
	mov	edx, DWORD PTR _head$[ebp]
	push	edx
	call	_is_list_circular
	add	esp, 4
	test	eax, eax
	je	SHORT $LN10@make_list_
$LN7@make_list_:
; Line 65
	mov	eax, 1
	test	eax, eax
	je	SHORT $LN6@make_list_
; Line 66
	mov	ecx, DWORD PTR _fast$[ebp]
	mov	edx, DWORD PTR [ecx+4]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR _fast$[ebp], eax
; Line 67
	mov	ecx, DWORD PTR _slow$[ebp]
	mov	edx, DWORD PTR [ecx+4]
	mov	DWORD PTR _slow$[ebp], edx
; Line 68
	mov	eax, DWORD PTR _slow$[ebp]
	cmp	eax, DWORD PTR _fast$[ebp]
	jne	SHORT $LN5@make_list_
; Line 69
	jmp	SHORT $LN6@make_list_
$LN5@make_list_:
; Line 71
	jmp	SHORT $LN7@make_list_
$LN6@make_list_:
; Line 72
	mov	ecx, DWORD PTR _head$[ebp]
	mov	DWORD PTR _fast$[ebp], ecx
$LN4@make_list_:
; Line 73
	mov	edx, DWORD PTR _fast$[ebp]
	cmp	edx, DWORD PTR _slow$[ebp]
	je	SHORT $LN3@make_list_
; Line 74
	mov	eax, DWORD PTR _fast$[ebp]
	mov	ecx, DWORD PTR [eax+4]
	mov	DWORD PTR _fast$[ebp], ecx
; Line 75
	mov	edx, DWORD PTR _slow$[ebp]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR _slow$[ebp], eax
; Line 76
	jmp	SHORT $LN4@make_list_
$LN3@make_list_:
; Line 77
	mov	ecx, DWORD PTR _fast$[ebp]
	mov	edx, DWORD PTR [ecx+4]
	mov	DWORD PTR _fast$[ebp], edx
$LN2@make_list_:
; Line 78
	mov	eax, DWORD PTR _fast$[ebp]
	mov	ecx, DWORD PTR [eax+4]
	cmp	ecx, DWORD PTR _slow$[ebp]
	je	SHORT $LN1@make_list_
; Line 79
	mov	edx, DWORD PTR _fast$[ebp]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR _fast$[ebp], eax
; Line 80
	jmp	SHORT $LN2@make_list_
$LN1@make_list_:
; Line 81
	mov	ecx, DWORD PTR _fast$[ebp]
	mov	DWORD PTR [ecx+4], 0
$LN10@make_list_:
; Line 83
	mov	esp, ebp
	pop	ebp
	ret	0
_make_list_acircular ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_tmp$ = -4						; size = 4
_head$ = 8						; size = 4
_make_list_circular PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 41
	push	ebp
	mov	ebp, esp
	push	ecx
; Line 44
	push	OFFSET $SG4318
	call	_printf
	add	esp, 4
; Line 46
	mov	eax, DWORD PTR _head$[ebp]
	mov	DWORD PTR _tmp$[ebp], eax
$LN2@make_list_:
; Line 47
	cmp	DWORD PTR _tmp$[ebp], 0
	je	SHORT $LN1@make_list_
	mov	ecx, DWORD PTR _tmp$[ebp]
	cmp	DWORD PTR [ecx+4], 0
	je	SHORT $LN1@make_list_
; Line 48
	mov	edx, DWORD PTR _tmp$[ebp]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR _tmp$[ebp], eax
; Line 49
	jmp	SHORT $LN2@make_list_
$LN1@make_list_:
; Line 50
	mov	ecx, DWORD PTR _tmp$[ebp]
	mov	edx, DWORD PTR _head$[ebp]
	mov	DWORD PTR [ecx+4], edx
; Line 52
	push	OFFSET $SG4322
	call	_printf
	add	esp, 4
; Line 54
	mov	esp, ebp
	pop	ebp
	ret	0
_make_list_circular ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_curr$ = -8						; size = 4
_tmp$ = -4						; size = 4
_head$ = 8						; size = 4
_insertVal$ = 12					; size = 4
_type$ = 16						; size = 4
_searchVal$ = 20					; size = 4
_insert_in_list_after PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 250
	push	ebp
	mov	ebp, esp
	sub	esp, 8
; Line 251
	mov	DWORD PTR _tmp$[ebp], 0
; Line 252
	mov	eax, DWORD PTR _head$[ebp]
	mov	DWORD PTR _curr$[ebp], eax
; Line 257
	mov	esp, ebp
	pop	ebp
	ret	0
_insert_in_list_after ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_tmp$ = -4						; size = 4
_head$ = 8						; size = 4
_val$ = 12						; size = 4
_type$ = 16						; size = 4
_head_insert_in_list PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 240
	push	ebp
	mov	ebp, esp
	push	ecx
; Line 241
	mov	DWORD PTR _tmp$[ebp], 0
; Line 242
	cmp	DWORD PTR _head$[ebp], 0
	jne	SHORT $LN1@head_inser
; Line 243
	jmp	SHORT $LN2@head_inser
$LN1@head_inser:
; Line 244
	mov	eax, DWORD PTR _type$[ebp]
	push	eax
	mov	ecx, DWORD PTR _val$[ebp]
	push	ecx
	call	_create_node
	add	esp, 8
	mov	DWORD PTR _tmp$[ebp], eax
; Line 245
	mov	edx, DWORD PTR _tmp$[ebp]
	mov	eax, DWORD PTR _head$[ebp]
	mov	DWORD PTR [edx+4], eax
; Line 246
	mov	ecx, DWORD PTR _tmp$[ebp]
	mov	DWORD PTR _head$[ebp], ecx
$LN2@head_inser:
; Line 247
	mov	esp, ebp
	pop	ebp
	ret	0
_head_insert_in_list ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_tmp$ = -12						; size = 4
_fast$ = -8						; size = 4
_slow$ = -4						; size = 4
_head$ = 8						; size = 4
_val$ = 12						; size = 4
_type$ = 16						; size = 4
_mid_insert_in_list PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 224
	push	ebp
	mov	ebp, esp
	sub	esp, 12					; 0000000cH
; Line 225
	mov	eax, DWORD PTR _head$[ebp]
	mov	DWORD PTR _fast$[ebp], eax
; Line 226
	mov	ecx, DWORD PTR _head$[ebp]
	mov	DWORD PTR _slow$[ebp], ecx
; Line 227
	mov	DWORD PTR _tmp$[ebp], 0
; Line 228
	cmp	DWORD PTR _head$[ebp], 0
	jne	SHORT $LN2@mid_insert
; Line 229
	jmp	SHORT $LN4@mid_insert
$LN2@mid_insert:
; Line 230
	cmp	DWORD PTR _fast$[ebp], 0
	je	SHORT $LN1@mid_insert
	cmp	DWORD PTR _slow$[ebp], 0
	je	SHORT $LN1@mid_insert
	mov	edx, DWORD PTR _fast$[ebp]
	cmp	DWORD PTR [edx+4], 0
	je	SHORT $LN1@mid_insert
; Line 231
	mov	eax, DWORD PTR _fast$[ebp]
	mov	ecx, DWORD PTR [eax+4]
	mov	edx, DWORD PTR [ecx+4]
	mov	DWORD PTR _fast$[ebp], edx
; Line 232
	mov	eax, DWORD PTR _slow$[ebp]
	mov	ecx, DWORD PTR [eax+4]
	mov	DWORD PTR _slow$[ebp], ecx
; Line 233
	jmp	SHORT $LN2@mid_insert
$LN1@mid_insert:
; Line 234
	mov	edx, DWORD PTR _type$[ebp]
	push	edx
	mov	eax, DWORD PTR _val$[ebp]
	push	eax
	call	_create_node
	add	esp, 8
	mov	DWORD PTR _tmp$[ebp], eax
; Line 235
	mov	ecx, DWORD PTR _tmp$[ebp]
	mov	edx, DWORD PTR _slow$[ebp]
	mov	eax, DWORD PTR [edx+4]
	mov	DWORD PTR [ecx+4], eax
; Line 236
	mov	ecx, DWORD PTR _slow$[ebp]
	mov	edx, DWORD PTR _tmp$[ebp]
	mov	DWORD PTR [ecx+4], edx
$LN4@mid_insert:
; Line 237
	mov	esp, ebp
	pop	ebp
	ret	0
_mid_insert_in_list ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_head$ = 8						; size = 4
_val$ = 12						; size = 4
_type$ = 16						; size = 4
_tail_insert_in_list PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 219
	push	ebp
	mov	ebp, esp
; Line 220
	mov	eax, DWORD PTR _type$[ebp]
	push	eax
	mov	ecx, DWORD PTR _val$[ebp]
	push	ecx
	mov	edx, DWORD PTR _head$[ebp]
	push	edx
	call	_add_to_list
	add	esp, 12					; 0000000cH
; Line 221
	pop	ebp
	ret	0
_tail_insert_in_list ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_head$ = 8						; size = 4
_val$ = 12						; size = 4
_type$ = 16						; size = 4
_position$ = 20						; size = 4
_insert_in_list PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 262
	push	ebp
	mov	ebp, esp
; Line 263
	cmp	DWORD PTR _position$[ebp], 0
	jne	SHORT $LN5@insert_in_
; Line 264
	mov	eax, DWORD PTR _type$[ebp]
	push	eax
	mov	ecx, DWORD PTR _val$[ebp]
	push	ecx
	mov	edx, DWORD PTR _head$[ebp]
	push	edx
	call	_tail_insert_in_list
	add	esp, 12					; 0000000cH
	jmp	SHORT $LN6@insert_in_
$LN5@insert_in_:
; Line 266
	cmp	DWORD PTR _position$[ebp], 1
	jne	SHORT $LN3@insert_in_
; Line 267
	mov	eax, DWORD PTR _type$[ebp]
	push	eax
	mov	ecx, DWORD PTR _val$[ebp]
	push	ecx
	mov	edx, DWORD PTR _head$[ebp]
	push	edx
	call	_head_insert_in_list
	add	esp, 12					; 0000000cH
	jmp	SHORT $LN6@insert_in_
$LN3@insert_in_:
; Line 269
	cmp	DWORD PTR _position$[ebp], 2
	jne	SHORT $LN6@insert_in_
; Line 270
	mov	eax, DWORD PTR _type$[ebp]
	push	eax
	mov	ecx, DWORD PTR _val$[ebp]
	push	ecx
	mov	edx, DWORD PTR _head$[ebp]
	push	edx
	call	_mid_insert_in_list
	add	esp, 12					; 0000000cH
$LN6@insert_in_:
; Line 272
	pop	ebp
	ret	0
_insert_in_list ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_newTS$ = -8						; size = 4
_tmp$ = -4						; size = 4
_head$ = 8						; size = 4
_val$ = 12						; size = 4
_type$ = 16						; size = 4
_add_to_list PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 25
	push	ebp
	mov	ebp, esp
	sub	esp, 8
; Line 28
	push	OFFSET $SG4308
	call	_printf
	add	esp, 4
; Line 30
	mov	eax, DWORD PTR _type$[ebp]
	push	eax
	mov	ecx, DWORD PTR _val$[ebp]
	push	ecx
	call	_create_node
	add	esp, 8
	mov	DWORD PTR _newTS$[ebp], eax
; Line 31
	mov	edx, DWORD PTR _head$[ebp]
	mov	DWORD PTR _tmp$[ebp], edx
$LN2@add_to_lis:
; Line 32
	mov	eax, DWORD PTR _tmp$[ebp]
	cmp	DWORD PTR [eax+4], 0
	je	SHORT $LN1@add_to_lis
; Line 33
	mov	ecx, DWORD PTR _tmp$[ebp]
	mov	edx, DWORD PTR [ecx+4]
	mov	DWORD PTR _tmp$[ebp], edx
; Line 34
	jmp	SHORT $LN2@add_to_lis
$LN1@add_to_lis:
; Line 35
	mov	eax, DWORD PTR _tmp$[ebp]
	mov	ecx, DWORD PTR _newTS$[ebp]
	mov	DWORD PTR [eax+4], ecx
; Line 37
	push	OFFSET $SG4313
	call	_printf
	add	esp, 4
; Line 39
	mov	esp, ebp
	pop	ebp
	ret	0
_add_to_list ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
_size$ = -8						; size = 4
_ptr$ = -4						; size = 4
_val$ = 8						; size = 4
_type$ = 12						; size = 4
_create_node PROC
; File d:\source\blog posts\linked lists\linked list.c
; Line 4
	push	ebp
	mov	ebp, esp
	sub	esp, 8
; Line 8
	mov	eax, DWORD PTR _val$[ebp]
	push	eax
	push	OFFSET $SG4292
	call	_printf
	add	esp, 8
; Line 10
	mov	DWORD PTR _size$[ebp], 12		; 0000000cH
; Line 11
	mov	ecx, DWORD PTR _size$[ebp]
	push	ecx
	call	_malloc
	add	esp, 4
	mov	DWORD PTR _ptr$[ebp], eax
; Line 12
	cmp	DWORD PTR _ptr$[ebp], 0
	jne	SHORT $LN1@create_nod
; Line 13
	call	_abort
$LN1@create_nod:
; Line 15
	mov	edx, DWORD PTR _ptr$[ebp]
	mov	eax, DWORD PTR _val$[ebp]
	mov	DWORD PTR [edx], eax
; Line 16
	mov	ecx, DWORD PTR _ptr$[ebp]
	mov	DWORD PTR [ecx+4], 0
; Line 17
	mov	edx, DWORD PTR _ptr$[ebp]
	mov	eax, DWORD PTR _type$[ebp]
	mov	DWORD PTR [edx+8], eax
; Line 19
	mov	eax, DWORD PTR _ptr$[ebp]
	jmp	SHORT $LN3@create_nod
; Line 21
	push	OFFSET $SG4298
	call	_printf
	add	esp, 4
$LN3@create_nod:
; Line 23
	mov	esp, ebp
	pop	ebp
	ret	0
_create_node ENDP
_TEXT	ENDS
END
